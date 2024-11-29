# WindMouse
This project is an unofficial implementation of [WindMouse](https://github.com/SRL/SRL-5/blob/master/SRL/core/mouse.simba#L44 "Official Pascal WindMouse") (realistic mouse movement) for .NET  
Also provides WinAPI functions for work with mouse.  
Project was created based on my needs and does not pretend to be an ideal implementation.  
Open for contributions.

# How to use (Examples)

Call ***MoveMouseWindAsync*** to async move mouse.  
~~~C#
MouseAPI.MoveMouseWindAsync(new(X,Y));
~~~
***MoveMouseWind*** and ***MoveMouseWindAsync*** provides some settings via params (setted to default), check the description of the method when calling.  
***MoveMouseWind*** blocks the thread untill move ends.

