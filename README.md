# 影像水印栅格函数
该栅格函数基于ESRI提供的示例代码修改而来，支持32位透明背景的PNG图片格式作为水印图片。可以指定水印的水平和垂直间隔距离和混合的透明度。
安装步骤如下：
1.打开XMLSupport.dat，添加如下内容：
    <Type>
		<Name>WatermarkFunction</Name>
		<Namespace>http://www.esri.com/schemas/ArcGIS/10.2</Namespace>
		<CLSID>{25BE29A6-AAF9-496E-AE73-130D5947682D}</CLSID>
    </Type>
    <Type>
		<Name>WatermarkFunctionArguments</Name>
		<Namespace>http://www.esri.com/schemas/ArcGIS/10.2</Namespace>
		<CLSID>{BD15CDB5-1EA6-47AC-B188-18C1DA5DE77F}</CLSID>
    </Type>
2.使用ESRIRegAsm注册dll。

