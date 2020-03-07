# MaskBooking

一个c#版本的预定脚本。来自 <https://github.com/542154968/getHfMask>

### 使用帮助 

1. 填写UserInfo.json用户信息。药房信息网上很多，这里就不提供了，可以参照原工程（所有均必填）

2. 填写BaiduOCR.json接口信息（选填），百度OCR接口请自行申请，免费的够自己用了。

3. 启动点击运行即可。

### 开发帮助

1. 安装 .Net Framework 4.7.2框架。

2. 还原解决方案Nuggets包

3. 更改前请运行所有单元测试，确保全部通过，否则请更新代码。

### 代码流程说明

1. 请求index.html，这里请求的原因是因为页面中有隐含的时间戳信息，后续提交时需要用到这个加密后提交到服务器验证，否则就会报请求频繁错误（猜测）。

2. 请求验证码，这里返回的时base64字符串，需要自己处理一下，返回的页面中包含了cookie信息，需要保存备用。

3. 请求库存信息，从这里开始提交的url必须带有时间戳与加密hash。

4. 提交购买请求，发送和请求都是json。

- 全程自行构造header

- 我只是<https://github.com/542154968/getHfMask>的搬运工。顺便感谢提供的帮助。

### 使用截图

![img](https://github.com/zc910704/MaskBooking/MaskBooking/Images/readme.png)
