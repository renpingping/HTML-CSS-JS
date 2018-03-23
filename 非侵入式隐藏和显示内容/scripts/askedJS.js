
//这里直接将单击事件处理程序赋给相关元素的onclick属性，
//并且是在body.onload事件处理程序中，这种方法可能影响页面中使用的其他脚本。
//可使用jQuery实现
window.onload = function(){
	var faqList, answers, questionLinks, questions, currentNode, i, j;
	faqList = document.getElementById("faq");
	answers = faqList.getElementsByTagName("dd");
	for (i=0;i<answers.length;i++){					//把所有的答案都设为隐藏
		answers[i].style.display = 'none';
	}

	questions = faqList.getElementsByTagName("dt");  //获取所有的<dt>标签，即所有的问题
	for(i=0;i<questions.length;i++){
		questions[i].onclick = function(){
			currentNode = this.nextSibling;			//寻找下一个兄弟节点
			while (currentNode){
				if(currentNode.nodeType == "1" && currentNode.tagName == "DD"){		//nodeType为 1，是元素节点
					if(currentNode.style.display == 'none'){
						currentNode.style.display = 'block';
					}
					else{
						currentNode.style.display = 'none';
					}
					break;
				}
				currentNode = currentNode.nextSibling;
			}
			return false;
		};
	}
};

/*
$(function(){
	$("#faq dd").hide();
	$("#faq dt").click(function(event){
		event.preventDefault();
		$(this).next("dd").toggle();
	});
});
*/

//添加一个链接用于一次展开/收缩所有回答
/*function addExpandAllLink(){
	var expandAllDiv, expandAllLink, faq;
	expandAllDiv = document.createElement("div");
	expandAllDiv.setAttribute("id","expandAll");

	expandAllLink = document.createElement("a");
	expandAllLink.setAttribute("href","#");
	expandAllLink.setAttribute("id","expandAllLink");
	expandAllLink.appendChild(document.createTextNode("Expand All"));

	expandAllDiv.appendChild(expandAllLink);

	expandAllLink.onclick = function(){
		var faqList, answers;
		faqList = document.getElementById("faq");
		answers = faqList.getElementsByTagName("dd");

		if(this.innerHTML == "Expand All"){
			for(i=0;i<answers.length;i++){
				answers[i].style.display = 'block';
			}
			this.innerHTML = "Collapse All";
		}
		else{
			for(i=0;i<answers.length;i++){
				answers[i].style.display = 'none';
			}
			this.innerHTML = "Expand All";
		}
		return false;
	};
	faq = document.getElementById("faq");
	faq.insertBefore(expandAllDiv, faq.firstChild);
}*/

//判断通过问答展开情况设置链接状态
/*	var faqList, answers, expandAllLink, switchLink;
	faqList = document.getElementById("faq");
	answers = faqList.getElementsByTagName("dd"); 
	expandAllLink = document.getElementById("expandAllLink");
	switchLink = true;

	if (expandAllLink.innerHTML == "Expand All"){
		for (i=0; i<answers.length; i++){
			if (answers[i].style.display == 'none'){
				switchLink = false;
			}
		}
		if(switchLink){
			expandAllLink.innerHTML == "Collapse All";
		}
	}
	else {
		for (i=0;i<answers.length;i++){
			if (answers[i].style.display == 'block'){
				switchLink = false;
			}
		}
		if(switchLink){
			expandAllLink.innerHTML == "Expand All";
		}
	}
}*/

//使用就jQuery实现，添加一个链接，判断通过问答展开情况设置链接状态
$(function(){
	$("<a href='#' id ='expandAll'>Expand All</a>").insertAfter("h1");

	$("#expandAll").click(function(event){
		event.preventDefault();

		if($(this).html() == 'Expand All'){
			$("#faq dd").show();
			$(this).html("Collapse All");
		}else{
			$("#faq dd").hide();
			$(this).html('Expand All');
		}
	});
});
//addExpandAllLink();
//updateExpandAllLink();


/*
用于访问DOM的方法：
	getElementById(id)：获取ID为指定值的元素。
	getElementsByTagName(name)：获取一系列与指定标签名相匹配的元素。
		也可对特定元素调用这个方法，在这种情况下，它将返回所用使用指定标签名的后代元素。
	getElementByName(name)：获取属性name为指定值得元素。
		通常用于获取表单或表单字段，因为表单和表单字段都使用name属性。

可用于DOM中导航的节点属性：
	 childNodes： 一个数组，包含所有的子节点。
	 firstChild： 第一子节点。
	  innerHTML： 节点中的标记和内容，可通过设置这个属性来修改节点的内容。
	  lastChlid： 最后一个子节点。
   	nextSibling： 下一个兄弟节点（在DOM树中，它与当前节点位于相同的层级）。
	 parentNode： 当前节点的父节点。
previousSibling： 位于当前节点前面且属于同一个层级的节点。
	
属性nodeType包含一个标识节点类型的数字。
	元素节点的节点类型为1；
	属性节点的节点类型为2；
	文本节点的节点类型为3；

修改文档的方法：
	        appendChild(element)：在目标元素中添加子元素。
	      insertBefore(new, ref)：在目标元素中的ref子元素前插入子元素new.
	       removeAttribute(name)：将目标元素的属性name删除。
	        removeChild(element)：从目标元素中删除参数指定的子元素。
replaceChild(inserted, replaced)：将目标元素中的子元素replaced替换为元素inserted。
	   setAttribute(name, value)：将目标元素的属性name的值设置为value。


*/