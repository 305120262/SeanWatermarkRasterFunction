# 影像水印栅格函数
  该栅格函数基于ESRI提供的示例代码修改而来，支持32位透明背景的PNG图片格式作为水印图片。可以指定水印的水平和垂直间隔距离和混合的透明度。
##下面为注册到ArcGIS for Desktop中的具体步骤描述。
  1.打开XMLSupport.dat
  2.添加如下内容：
```xml
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
```
  3.使用ESRIRegAsm注册dll，在弹出的对话框中选择Desktop。
  
##下面为注册到ArcGIS for Server中的具体步骤描述：
  1. 打开cmd，使用ESRIRegAsm.exe [32bit dll保存路径] /regfile:watermarkfunction.reg。
  2. 使用记事本打开.reg文件，修改里面的内容，把/codebase的路径修改为64bit dll的保存路径。
  3. 打开cmd，使用regedit [.reg文件保存路径]。


