
$(function(){
	//点击链接，清除列表项
	//empty()：删除元素的内容
	//slideUp()设置上滑效果。
	$("#clearList").click(function(event){
		event.preventDefault();
		$("#editable").slideUp('slow',function(){
			$("#editable").empty();
			$("#editable").show();    
			//show()以便用户再次添加新列表后，可以看到列表。把display：none删除。
		});
	});

	//点击提交按钮，增加<li>标签和其内容
	//prepend(),可在列表项开头加入列表项，即加入<ul>内。
	//还可使用before()和after()分别再选定元素前面和后面添加内容，即在<ul>外（之前之后）加入。

	//append()和appendTo()差别在于，
	//append()所属的对象表示容器的选择器，参数是要附加的内容，
	//appendTo()所属的对象是要附加的内容，参数是表示容器的选择器。

	//fadeIn()方法将列表项的display属性设置为block，这将导致列表项没有项目符号，
	//通过将属性display设置为list-item，可确保列表项在任何浏览器中都有项目符号。
	$("#addElement").submit(function(event){
		event.preventDefault();
		var content = "<li>"+$("#addElement input[name='liContent']").val() + "</li>" 
		$(content).hide().appendTo("#editable").fadeIn('slow').css("display","list-item");
		//此句使用了方法串接。几乎所有的jQuery方法都返回它的操作对象，所以使用hide()时，它也会返回被隐藏的元素。
		//这里对表示新内容的jQuery对象依次调用了hide()、appendTo()、fadeIn()和css()。
		//先调用hide()以免将内容加入列表时它立即出现。
		//使用appendTo()将内容加入列表。

		//$("#editable").append(content).hide().fadeIn('slow');  
		//这个方法不如上面的好，调用hide()时会使整个列表都隐藏。
		$("#addElement input[name='liContent']").val("").focus();
	});

	//由于页面加载时没有li项，也就没有click事件，动态给li添加click事件，及事件处理程序
	//使用方法on()和选择器document，指出监视页面变化，并添加与选择器匹配的元素关联到的事件
	// 		第一个参数：关联到的事件的名称；
	//  	第二个参数：用于匹配元素的选择器；
	//  	第三个参数：事件处理程序。
	
	//fadeOut()添加淡出效果，将元素的display属性设置为none，效果和hide基本相同。
	//		第一个参数：用于指定动画的速度。slow意味着动画将持续600毫秒；默认400毫秒；fast：200毫秒。
	//		第二个参数：指定一个回调函数，在动画结束后被调用
	$(document).on('click',"#editable li",function(){
		$(this).fadeOut('slow',function(){
			$(this).remove();
		});
	});
});
