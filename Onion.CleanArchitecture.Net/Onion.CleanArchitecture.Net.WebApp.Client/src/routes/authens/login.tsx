// src/pages/LoginPage.tsx
import { authProvider } from "@providers/index";
import React, { useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";

const LoginPage: React.FC = () => {
  const { search } = useLocation();
  const navigate = useNavigate();

  useEffect(() => {
    const handleLogin = async () => {
      const params = new URLSearchParams(search);
      const jwtoken = params.get("jwtoken");

      if (jwtoken) {
        const result = await authProvider.loginJwt({ jwtoken });

        if (result.success) {
          navigate("/");
        } else {
          navigate("/login");
        }
      } else {
        navigate("/login");
      }
    };

    handleLogin();
  }, [search, navigate]);

  return (
    <div>
      <h1>Logging in...</h1>
    </div>
  );
};

export default LoginPage;
