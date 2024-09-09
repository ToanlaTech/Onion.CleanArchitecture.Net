import {
  AuthPage,
  ErrorComponent,
  ImageField,
  ThemedLayoutV2,
  ThemedTitleV2,
} from "@refinedev/antd";
import { Authenticated, CanAccess } from "@refinedev/core";
import {
  CatchAllNavigate,
  NavigateToResource,
} from "@refinedev/react-router-v6";
import { Outlet, Route, Routes } from "react-router-dom";
import { ProtectedRoutes } from "./protected";
import { Unauthorized } from "@components/unauthorized";
import CustomTitleAvatar from "@components/custom-title";
import LoginPage from "@routes/authens/login";

export const AppRoutes = () => {
  return (
    <Routes>
      <Route
        element={
          <Authenticated
            key="authenticated-routes"
            fallback={<CatchAllNavigate to="/login" />}
          >
            {/* <ThemedLayoutV2
              Title={({ collapsed }: any) => (
                <ThemedTitleV2
                  collapsed={collapsed}
                  icon={
                    <ImageField
                      value="https://static.toananhle.com.vn/web/toananhle-logo.png"
                      title="toananhle Logo"
                      style={{ width: 30, height: 30 }}
                    />
                  }
                  text="toananhle Admin"
                />
              )}
            >
              <Outlet />
            </ThemedLayoutV2> */}
            <ThemedLayoutV2
              Title={({ collapsed }) => (
                <CustomTitleAvatar collapsed={collapsed} />
              )}
            >
              <Outlet />
            </ThemedLayoutV2>
          </Authenticated>
        }
      >
        <Route index element={<NavigateToResource resource="dashboard" />} />

        {ProtectedRoutes.map((item, index) => (
          <Route path={item.resource} key={index}>
            {item?.children?.map((child, key) => (
              <Route
                index={child?.index ? true : false}
                path={child.path || undefined}
                key={key}
                element={
                  <CanAccess
                    resource={item?.resource}
                    action={child?.action}
                    fallback={item?.fallback || <Unauthorized />}
                  >
                    {child?.element}
                  </CanAccess>
                }
              />
            ))}
          </Route>
        ))}
      </Route>
      <Route
        element={
          <Authenticated key="auth-pages" fallback={<Outlet />}>
            <NavigateToResource />
          </Authenticated>
        }
      >
        <Route path="/authen" element={<LoginPage />} />
        <Route
          path="/login"
          element={
            <AuthPage
              type="login"
              title={
                <ThemedTitleV2
                  // icon={
                  //   <ImageField
                  //     value="https://static.toananhle.com.vn/web/toananhle-logo.png"
                  //     title="toananhle Logo"
                  //     style={{ width: 30, height: 30 }}
                  //   />
                  // }
                  text="Admin"
                  collapsed={false}
                />
              }
              forgotPasswordLink={false}
              registerLink={false}
              formProps={{
                initialValues: {
                  email: "",
                  password: "",
                },
              }}
            />
          }
        />
      </Route>
      <Route
        element={
          <Authenticated key="catch-all">
            <ThemedLayoutV2>
              <Outlet />
            </ThemedLayoutV2>
          </Authenticated>
        }
      >
        <Route path="*" element={<ErrorComponent />} />
      </Route>
    </Routes>
  );
};

export default AppRoutes;
