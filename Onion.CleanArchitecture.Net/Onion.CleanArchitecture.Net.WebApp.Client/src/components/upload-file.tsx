import { InboxOutlined } from "@ant-design/icons";
import { removeAccent } from "@utilities/removeAccent";
import type { GetProp, UploadProps } from "antd";
import { Card, Form, Typography, Upload, message } from "antd";
import React, { useEffect, useState } from "react";

const { Dragger } = Upload;

const urlUpload = `${"https://localhost:7058/api/file/multiple?folder=FTP"}`;

const formItemLayout = {
  labelCol: {
    xs: { span: 24 },
    sm: { span: 24 },
  },
  wrapperCol: {
    xs: { span: 24 },
    sm: { span: 24 },
  },
};

type ImageUploadProps = {
  setFieldsValue: ((values: any) => void) | undefined;
  imageUrl?: string;
  fieldName: string;
};

type FileType = Parameters<GetProp<UploadProps, "beforeUpload">>[0];

const UploadFile: React.FC<ImageUploadProps> = ({
  setFieldsValue,
  imageUrl: initialImageUrl,
  fieldName,
}) => {
  const [imageUrl, setImageUrl] = useState<string | undefined>(initialImageUrl);
  const [loading, setLoading] = useState(false);
  useEffect(() => {
    if (initialImageUrl) {
      setImageUrl(initialImageUrl);
    }
  }, [initialImageUrl]);

  const beforeUpload = (file: FileType) => {
    const checkName = removeAccent(file.name);
    const isPdfOrExcelOrJpgOrPng =
      file.type === "image/jpeg" ||
      file.type === "image/png" ||
      file.type === "application/pdf" ||
      file.type ===
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    if (!isPdfOrExcelOrJpgOrPng) {
      message.error("You can only upload JPG/PNG/PDF/Excel files!");
    }
    const isLt20M = file.size / 1024 / 1024 < 20;
    if (!isLt20M) {
      message.error("File must be smaller than 20MB!");
    }
    if (!checkName) {
      message.error("File name contains invalid characters!");
    }
    return isLt20M && isPdfOrExcelOrJpgOrPng && checkName;
  };

  const handleChange: UploadProps["onChange"] = (info) => {
    if (info.file.status === "uploading") {
      setLoading(true);
      return;
    }
    if (info.file.status === "done") {
      if (info.file.response && info.file.response.files[0]) {
        const urlResponse = info.file.response.files[0].url;
        setImageUrl(urlResponse);
        if (setFieldsValue) {
          const fieldUpdate = { [fieldName]: urlResponse };
          setFieldsValue(fieldUpdate);
        }
        message.success(`${info.file.name} file uploaded successfully`);
      }
      setLoading(false);
    } else if (info.file.status === "error") {
      message.error(`${info.file.name} file upload failed.`);
      setLoading(false);
    }
  };

  const handleRemove: UploadProps["onRemove"] = async (file) => {
    const fileDelete = file.response?.files[0];
    if (fileDelete) {
      const nameFile = fileDelete.name;
      try {
        await fetch(`${urlUpload}/${nameFile}`, {
          method: "DELETE",
        });
        message.success(`${nameFile} file removed successfully`);
        setImageUrl("");
        if (setFieldsValue) {
          const fieldUpdate = { [fieldName]: "" };
          setFieldsValue(fieldUpdate);
        }
      } catch {
        message.error(`${nameFile} file removal failed.`);
      }
    }
  };

  return (
    <Card
      className="card-custom"
      style={{ background: "white" }}
      title={
        <Typography style={{ color: "#1677FF", background: "white" }}>
          III. Chứng từ đính kèm
          <span
            style={{ fontWeight: "normal", fontSize: "12px", margin: "4px" }}
          >
            (Tối đa 5 file - PDF hoặc Excel)
          </span>
        </Typography>
      }
    >
      <Form.Item
        {...formItemLayout}
        name="upload"
        style={{ flex: 1, marginBottom: 0 }}
        rules={[
          { required: true, message: "Please upload at least one file." },
        ]}
      >
        <Dragger
          name="uploadedFiles"
          action={urlUpload}
          // fileList={fileList}
          beforeUpload={beforeUpload}
          onChange={handleChange}
          onRemove={handleRemove}
          maxCount={5}
          multiple={true}
          accept=".pdf, .xlsx, image/png, image/jpeg"
        >
          <p className="ant-upload-drag-icon">
            <InboxOutlined />
          </p>
          <Typography className="ant-upload-text">
            Chọn tập tin hoặc kéo thả vào đây
          </Typography>
          <Typography.Text className="ant-upload-hint">
            Hỗ trợ tải lên một hoặc nhiều tập tin. (PDF hoặc Excel)
          </Typography.Text>
        </Dragger>
      </Form.Item>
    </Card>
  );
};

export default UploadFile;
