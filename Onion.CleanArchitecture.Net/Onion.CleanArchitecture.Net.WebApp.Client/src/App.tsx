import {
  useNotificationProvider
} from "@refinedev/antd";
import { Refine } from "@refinedev/core";
import routerProvider from "@refinedev/react-router-v6";
import { App as AntdApp, ConfigProvider } from "antd";
import React from "react";
import { BrowserRouter } from "react-router-dom";
import { resources, themeConfig } from "./config";
import { accessControlProvider, authProvider, dataProvider } from "./providers";
import AppRoutes from "./config/appRoutes";

const App: React.FC = () => {
  return (
    <BrowserRouter>
      <ConfigProvider theme={themeConfig}>
        <AntdApp>
          <Refine
            dataProvider={dataProvider}
            authProvider={authProvider}
            routerProvider={routerProvider}
            accessControlProvider={accessControlProvider}
            notificationProvider={useNotificationProvider}
            options={{
              syncWithLocation: true,
              warnWhenUnsavedChanges: true,
            }}
            resources={resources}
          >
            <AppRoutes />
          </Refine>
        </AntdApp>
      </ConfigProvider>
    </BrowserRouter>
  );
};

export default App;
