//  $(function(){
// 	function  display(id){  
//         var traget=$(id);  
//         if(traget.is(':hidden')){  
//               traget.show(); 
//               console.log("traget1");
//         }else{  
//             traget.hide();         
//             console.log("traget2");
//       }  
//    }  

// 	$("#switchCity").click(function(){
// 		display("#selectCity");
// 	});
// // $('body').on('click','#switchCity',function(){
// //             	wordsNum($(this),10);
// //             });


// });

// function Layer_HideOrShow(cur_div)  
// { 
// 	var current=document.getElementById(cur_div);  
// 	if(current.style.visibility=="hidden")  
// 	{  
// 		current.style.visibility ="visible";  
// 	}  
// 	else  
// 	{  
// 		current.style.visibility ="hidden";  

// 	}  
// }  

function showDiv(targetid){
	var target=document.getElementById(targetid);
	if (target.style.display=="block"){
		target.style.display="none";
	} else {
		target.style.display="block";
	}

}




function showDate(){
	var dayNames = new Array("星期日","星期一","星期二","星期三","星期四","星期五","星期六");
	var mydate = new Date();
	// var str = "" + mydate.getFullYear() + "年";
 //   str += (mydate.getMonth()+1) + "月";//拼接字符串，将前面的字符串加上后面的字符串，相当于i+=1；
 //   str += mydate.getDate() + "日";
 var str = dayNames[mydate.getDay()];  
   return str;
} 

function showTime(){
	var mytime = new Date();
	var str = "" + mytime.getHours() + "：";
   str += mytime.getMinutes()+ "：";//拼接字符串，将前面的字符串加上后面的字符串，相当于i+=1；
   str += mytime.getSeconds();
   return str;
} 

function showWeek(){
	var dayNames = new Array("星期日","星期一","星期二","星期三","星期四","星期五","星期六");
	var preWeek=document.getElementById('preWeek');
	var links= preWeek.querySelectorAll(".week");
	var myweek = new Date();

var nowDateNum=myweek.getDay();
	for (var i = 0; i < links.length; i++) {
  		links[i].innerHTML=dayNames[++nowDateNum==7?nowDateNum=0:nowDateNum];
	}


	// var nowDateNum=myweek.getDay();
	// for (var i = 0; i < links.length; i++) {
	// 	nowDateNum++;
	// 	if (nowDateNum==7) {			
	// 		nowDateNum=0;
	// 	}
	// 	var preWeekDate=dayNames[nowDateNum];
	// 	links[i].innerHTML=preWeekDate;
	// }


	// cycleWeek:
	// for (var i = 0; i < links.length; i++) {
	// 	var preWeekDate=dayNames[myweek.getDay()+i+1];
	// 	var nowDateNum=myweek.getDay()+i+1;
	// 	if (nowDateNum==7) {
	// 		for (var j=0; j<links.length-i; j++) {				
	// 			var firDate=dayNames[j];
			
	// 			links[i+j].innerHTML=firDate;
	// 		};
	// 	break cycleWeek;
	// 	}
	// 	else{
	// 		links[i].innerHTML=preWeekDate;
	// 	};
	// };
}


function initial(){
	var pp=document.getElementById("curWeek");
	var cc=showDate();
	pp.innerHTML=cc;

	var aa=document.getElementById("nowTime");
	var bb="现在是 " + showTime();
	aa.innerHTML=bb;

	var button=document.getElementById("switchCity");	
	button.onclick=function(){
		showDiv('selectCity');

	}	
}	


window.onload = function(){

	initial();
	showWeek();
}
