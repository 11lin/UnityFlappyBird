Android策略
首先Unity导出Gradle工程到自己建的Android目录下，添加渠道SDK、.so、java代码都在Gradle工程下。
以后项目加新功能或者有修改代码，资源需要重新导出到其他目录我这里是Android/Export。
Unity导出的时候，不能直接选择Android目录，这样操作会覆盖我们自己的修改。
然后把Export/FlappyBird/src/main/assets/bin目录下的资源拷贝到FlappyBird/src/main/assets/bin
主要是Unity资源需要更新，
也可以写一个脚本同步两个目录，mac或者cygwin推荐用rsync有修改才同步。
C#调用Java方法或者Java调用C#方法见文件：UnityAndroidHelper.cs

demo keystore
flappybird
密码 abc123456