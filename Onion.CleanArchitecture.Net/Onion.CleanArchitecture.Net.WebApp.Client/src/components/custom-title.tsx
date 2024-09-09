import React from "react";
import { useStyles } from "./style";
import { useGetIdentity, useGo, useOne } from "@refinedev/core";
import { IUser } from "@routes/identity/users";
import { CustomAvatar } from "./custom-avatar";
import { ImageField, ThemedTitleV2 } from "@refinedev/antd";

const CustomTitleAvatar: React.FC<{ collapsed: boolean }> = ({ collapsed }) => {
  const { styles } = useStyles();
  const { data: user } = useGetIdentity<IUser>();
  const go = useGo();

  const { data: UserLoginData } = useOne({
    resource: "users",
    id: user?.Uid,
  });
  const userLogin = UserLoginData?.data ?? null;
  return (
    <>
      {userLogin && userLogin?.Email != 'superadmin@gmail.com' ? (
        <div
          className={styles.avatar}
          style={{
            cursor: "pointer",
            marginTop: "50px",
            width: "100%",
            
          }}
          onClick={() =>
            go({
              to: "user-profile",
            })
          }
        >
          <CustomAvatar
            sizeAvatar={60}
            src={`https://documents.toananhle.com.vn/avatar/${userLogin?.Email}.jpg`}
            
            name={`${userLogin?.FirstName} 
                        ${userLogin?.LastName}`}
            style={{ marginBottom: "4px" }}
          />
          {!collapsed && (
            <div className={styles.titleAvatar}>
              <div style={{ fontWeight: "500", fontSize: "12px" }}>
                {userLogin?.FirstName} {userLogin?.LastName}
              </div>
              <div style={{ fontSize: "11px" }}>{userLogin?.ChucVu}</div>
            </div>
          )}
        </div>
      ) : (
        <>
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
        </>
      )}
    </>
  );
};

export default CustomTitleAvatar;
