using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace Onion.CleanArchitecture.Net.WebApp.Server.Controllers.v1
{
    [Route("api/file")]
    public class FileController : BaseApiController

    {
        private readonly IMinioClient _minioClient;
        private readonly IHostEnvironment _hostEnv;
        private readonly IConfiguration _config;
        private readonly string _bucketName;

        [Obsolete]
        public FileController(
         Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IConfiguration config, IMinioClient minioClient) : base(hostingEnvironment)
        {
            _minioClient = minioClient;
            _config = config;
            if (hostingEnvironment.IsDevelopment())
            {
                _bucketName = _config["S3Setting:BucketName"] ?? "bucket-01";
            }
            else
            {
                _bucketName = Environment.GetEnvironmentVariable("S3_BUCKET_NAME") ?? "bucket-01";
            }
        }

        // POST upload file to S3 bucket
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file, [FromForm] string folder)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or not selected.");
            }

            var objectName = string.IsNullOrEmpty(folder) ? file.FileName : $"{folder.TrimEnd('/')}/{file.FileName}";

            try
            {
                // Upload file to S3
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0; // Reset stream position

                    var putObjectArgs = new PutObjectArgs()
                                            .WithBucket(_bucketName)
                                            .WithObject(objectName)
                                            .WithStreamData(stream)
                                            .WithObjectSize(stream.Length)
                                            .WithContentType(file.ContentType);

                    await _minioClient.PutObjectAsync(putObjectArgs);
                }

                // Generate custom URL for the uploaded file
                var fileUrl = $"/api/file?file={Uri.EscapeDataString(objectName)}";


                return Ok(new { objectName, fileUrl });
            }
            catch (MinioException e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // POST upload multiple files to S3 bucket
        [HttpPost("multiple")]
        public async Task<IActionResult> PostMultiple(List<IFormFile> uploadedFiles, [FromForm] string folder)
        {
            if (uploadedFiles == null || uploadedFiles.Count == 0)
            {
                return BadRequest("No files are selected.");
            }

            var files = new List<object>();

            foreach (var file in uploadedFiles)
            {
                if (file == null || file.Length == 0)
                {
                    continue; // Skip empty files
                }

                var objectName = string.IsNullOrEmpty(folder) ? file.FileName : $"{folder.TrimEnd('/')}/{file.FileName}";

                try
                {
                    // Upload file to S3
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        stream.Position = 0; // Reset stream position

                        var putObjectArgs = new PutObjectArgs()
                                                .WithBucket(_bucketName)
                                                .WithObject(objectName)
                                                .WithStreamData(stream)
                                                .WithObjectSize(stream.Length)
                                                .WithContentType(file.ContentType);

                        await _minioClient.PutObjectAsync(putObjectArgs);
                    }

                    // Generate custom URL for the uploaded file
                    var response = new
                    {
                        Url = $"/api/file?file=?file={Uri.EscapeDataString(objectName)}",
                        Name = file.FileName,
                    };

                    files.Add(response);
                }
                catch (MinioException e)
                {
                    // If an error occurs, continue to next file
                    continue;
                }
            }

            return Ok(new { files });
        }


        [HttpGet]
        public async Task<IActionResult> Get(string file)
        {
            try
            {
                var memoryStream = new MemoryStream();
                var getObjectArgs = new GetObjectArgs()
                                        .WithBucket(_bucketName)
                                        .WithObject(file)
                                        .WithCallbackStream(stream =>
                                        {
                                            stream.CopyTo(memoryStream);
                                        });

                await _minioClient.GetObjectAsync(getObjectArgs);
                memoryStream.Position = 0;

                // Determine the content type based on the file extension
                var contentType = GetMimeType(file);

                // return File(memoryStream, contentType, file);
                return new FileStreamResult(memoryStream, contentType);

            }
            catch (MinioException e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // DELETE: delete file from S3 bucket
        [HttpDelete]
        public async Task<IActionResult> Delete(string file)
        {
            try
            {
                var removeObjectArgs = new RemoveObjectArgs()
                                            .WithBucket(_bucketName)
                                            .WithObject(file);

                await _minioClient.RemoveObjectAsync(removeObjectArgs);

                return Ok($"File '{file}' has been deleted successfully.");
            }
            catch (MinioException e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }


        // Helper method to get content type based on file extension
        private string GetContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
        private string GetMimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            switch (extension)
            {
                case ".doc":
                    return "application/msword";
                case ".docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".ppt":
                    return "application/vnd.ms-powerpoint";
                case ".pptx":
                    return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                case ".pdf":
                    return "application/pdf";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".jpe":
                    return "image/jpeg";
                case ".jpeg":
                    return "image/jpeg";
                case ".jpg":
                    return "image/jpeg";
                case ".jfif":
                    return "image/pjpeg";
                default:
                    return "application/octet-stream";
            }
        }
    }
}