<p align="center">
  <img src="logo.ico" alt="RGBToIndex Logo" width="100">
</p>

<h1 align="center">RGBToIndex — 真彩色转索引色查询器</h1>

<p align="center">
  <strong>输入 RGB 真彩色值，快速查找最接近的索引色</strong>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Platform-Windows-blue?logo=windows" alt="Platform">
  <img src="https://img.shields.io/badge/.NET-Framework%204.7.2-purple?logo=dotnet" alt=".NET Framework">
  <img src="https://img.shields.io/badge/Language-C%23-green?logo=csharp" alt="C#">
  <img src="https://img.shields.io/badge/License-MIT-yellow" alt="License">
  <img src="https://img.shields.io/github/stars/RegalZzz/RGBToIndex?style=social" alt="Stars">
</p>

---

## 📖 简介

**RGBToIndex** 是一款轻量级的 Windows 桌面工具，用于将 **RGB 真彩色**（24-bit）转换为最接近的**索引色**（Indexed Color）。

在 CAD、GIS、图像处理、打印等领域，经常需要在有限的调色板中找到与目标颜色最匹配的索引色。本工具通过 **欧氏距离算法** 自动计算色差，帮助你快速定位最接近的索引色值。

## ✨ 功能特性

- 🎨 **RGB 转索引色** — 输入 R/G/B 三通道值，一键查询最接近的索引色
- 🔍 **精确匹配 / 相似匹配** — 自动判断是"等于"还是"相似"，并显示色差距离
- 🖼️ **颜色预览** — 实时显示输入色与匹配色的色块对比
- 📋 **内置调色板** — 内置约 250 种标准索引色映射表
- ⚡ **轻量快速** — 纯本地计算，无需联网，毫秒级响应

## 🚀 快速开始

### 环境要求

- Windows 7 及以上
- .NET Framework 4.7.2（[下载运行时](https://dotnet.microsoft.com/download/dotnet-framework/net472)）

### 安装使用

**方式一：下载发布包**

1. 前往 [Releases](https://github.com/RegalZzz/RGBToIndex/releases) 页面下载最新版本
2. 解压后双击 `RGB2Index.exe` 即可运行

**方式二：从源码编译**

```bash
# 克隆仓库
git clone https://github.com/RegalZzz/RGBToIndex.git

# 使用 Visual Studio 打开解决方案
# 打开 RGB2Index.sln → 生成解决方案 (Ctrl+Shift+B)
```

## 📸 使用方法

1. 在 **R**、**G**、**B** 三个输入框中分别填入 0-255 的颜色值
2. 点击 **查询** 按钮
3. 查看结果：
   - 左侧色块显示输入的真彩色
   - 右侧色块显示匹配到的索引色
   - 中间标注 **"等于"**（精确匹配）或 **"相似"**（最近匹配）
   - 底部显示对应的索引色编号

## 🗂️ 项目结构

```
RGBToIndex/
├── App.xaml / App.xaml.cs          # 应用程序入口
├── MainWindow.xaml                 # 主窗口 UI 布局
├── MainWindow.xaml.cs              # 核心逻辑（颜色匹配算法）
├── RGB2Index.csproj                # 项目文件
├── RGB2Index.sln                   # 解决方案文件
├── Properties/                     # 程序集信息、资源、设置
├── logo.ico                        # 应用图标
└── README.md
```

## 🛠️ 技术栈

| 技术 | 说明 |
|------|------|
| C# | 主要开发语言 |
| WPF (XAML) | 桌面 UI 框架 |
| .NET Framework 4.7.2 | 运行时框架 |
| Visual Studio | 推荐的开发/编译 IDE |

## 📄 License

本项目基于 [MIT License](LICENSE) 开源。

## ⭐ 支持项目

如果这个工具对你有帮助，欢迎点个 **Star** ⭐ 支持一下！
