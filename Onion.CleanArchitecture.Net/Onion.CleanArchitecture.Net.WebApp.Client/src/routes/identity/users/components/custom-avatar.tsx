import { FC, memo } from "react";

import type { AvatarProps } from "antd";
import { Avatar as AntdAvatar } from "antd";

import { getNameInitials, getRandomColorFromString } from "@utilities/index";
import { AvatarSize } from "antd/es/avatar/AvatarContext";

type Props = AvatarProps & {
    name?: string;
    sizeAvatar?: AvatarSize;
};

const CustomAvatarComponent: FC<Props> = ({ name = "", sizeAvatar, style, ...rest }) => {
    return (
        <AntdAvatar
            alt={name}
            size={sizeAvatar || 'default'}
            style={{
                backgroundColor: rest?.src
                    ? "transparent"
                    : getRandomColorFromString(name),
                display: "flex",
                alignItems: "center",
                border: "none",
                ...style,
            }}
            {...rest}
        >
            {getNameInitials(name)}
        </AntdAvatar>
    );
};

export const CustomAvatarUsers = memo(
    CustomAvatarComponent,
    (prevProps, nextProps) => {
        return (
            prevProps.name === nextProps.name && prevProps.src === nextProps.src
        );
    },
);
