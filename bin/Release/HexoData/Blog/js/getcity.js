	//大神代码：
// 	var provincesNum = 0;	
// 	function getProvince(){
// 	    var strs="<select id='provinces1'><option>请选择自治区/省/直辖市</option>"; 
// 		for(var i=0;i<city.length;i++) { 
// 			strs=strs+"<option value="+i+">"+city[i][1]+"</option>"; 
// 		}
// 		strs=strs+"</select>"; 
// 		document.getElementById('province').innerHTML=strs; 
// 	} 

// 	function getRegion() {
// 		if($(this).val() == -1) return;
// 		//document.getElementById("city").innerHTML=""; 
// 		var provinces=document.getElementById("provinces1"); 
// 		//console.log(provinces[provinces.selectedIndex].value);
// 		var prov = provincesNum =provinces[provinces.selectedIndex].value; 
// 		//console.log(prov);	
// 		$('#city').html(getChilrenCity(city[prov]));
// 	}

// function getArea(){
// 		document.getElementById("area").innerHTML="";
// 		var provinces=document.getElementById("city");
// 		provinces = $('#city select')[0]
// 		// console.log("aaa"+provinces[provinces.selectedIndex].value);
// 		var prov=provinces[provinces.selectedIndex].value; 	
// 		// console.log(city[provincesNum][2][prov])	
// 		$('#area').html(getChilrenCity(city[provincesNum][2][prov]));

// 	}
	


// 	function getChilrenCity(array){
// 		var strs = "<select><option value='-1'>请选择...</option>"
// 		for (var i = 0; i < array[2].length; i++) {
// 			strs=strs+"<option value="+i+">"+array[2][i][1]+"</option>"; 
// 		}
// 		strs+="</select>"
// 		return strs;
// 	}
// 	function bindEvent(){
// 		$('#city').on('change','select',getArea)
// 		$('#province').on('change','select',getRegion);
		
// 	}


// 	bindEvent();
// 	getProvince();
	


//原生自己理解：
	 var provincesNum = 0;
	 var citysNum=0;
	 var areaNumber=101010200;
	function getProvince(){
	    var strs="<select id='provinces1'><option>请选择自治区/省/直辖市</option>"; 
		for(var i=0;i<city.length;i++) { 
			strs=strs+"<option value="+i+">"+city[i][1]+"</option>"; 
		}
		strs=strs+"</select>"; 
		document.getElementById('province').innerHTML=strs; 
		console.log(city);
	} 

	function getCity(){
	var strs="<select id='citys1'><option>请选择城市</option>"; 
	var provinces=document.getElementById("provinces1"); 
	var prov =provincesNum =provinces[provinces.selectedIndex].value; 
	console.log(provinces[provinces.selectedIndex].value);
	//console.log(city[prov]);
	for (var i = 0; i <city[prov][2].length;i++) {
		strs=strs+"<option value="+i+">"+city[prov][2][i][1]+"</option>"; 

	}
	strs=strs+"</select>"; 
	//console.log(strs);
	document.getElementById('city').innerHTML=strs; 
}

function getArea(){
	var strs="<select id='area1'><option>请选择区/县</option>"; 
	var provinces=document.getElementById("citys1"); 
	var prov =citysNum=provinces[provinces.selectedIndex].value; 
	//console.log(city[provincesNum][2][prov][2]);
	for (var i = 0; i <city[provincesNum][2][prov][2].length;i++) {
		strs=strs+"<option value="+i+">"+city[provincesNum][2][prov][2][i][1]+"</option>"; 
	//console.log(city[provincesNum][2][prov][2][i][1]);
	}
	strs=strs+"</select>"; 
	document.getElementById('area').innerHTML=strs; 
	}

function getAreaID(){
	var strs=" "; 
    var provinces=document.getElementById("area1"); 
    var prov =provinces[provinces.selectedIndex].value;
    var strs=areaNumber= city[provincesNum][2][citysNum][2][prov][2];
	console.log(areaNumber);
}



function bindEvent(){

		$('#city').on('change','select',getArea)
		$('#province').on('change','select',getCity)
		$('#area').on('change','select',getAreaID);
		$("#subCity").on('click',getData);
	}

	getData();
	bindEvent();
	getProvince();




function getData(){
    _url = 'http://weather.123.duba.net/static/weather_info/'+ areaNumber + '.html',
    $.get(_url, {}, function (data) {
        eval(data);
    });
}

function weather_callback(data){//从 eval(data)中看返回函数名
console.log(data.weatherinfo);
	//当前天气状态
	var city=data.weatherinfo.city;
	document.getElementById("curCity").innerHTML=city;

	var date=data.weatherinfo.date_y;
	document.getElementById("curDate").innerHTML=date;

	var temperature=data.weatherinfo.temp;
	document.getElementById("curTemperature").innerHTML=temperature;

    var curPic=data.weatherinfo.st1;
    var picUrl="http://www.duba.com/static/v2/images/weather/a/a"+curPic+".png"
    document.getElementById("curPic").setAttribute('src',picUrl);

	var state=data.weatherinfo.weather1;
	document.getElementById("curState").innerHTML=state;

	var dirWind=data.weatherinfo.wd;
	document.getElementById("dirWind").innerHTML=dirWind;

	var rankWind=data.weatherinfo.ws;
	document.getElementById("rankWind").innerHTML=rankWind;

	var quality=data.weatherinfo['pm-level'];//注意解析时候如果遇见字符串什么特殊字符浏览器不认的 可以用[]来查找对象
	document.getElementById("quality").innerHTML=quality;

	var pm=data.weatherinfo.pm;
	document.getElementById("pm").innerHTML=pm;

	var humidity=data.weatherinfo.sd;
	document.getElementById("humidity").innerHTML=humidity;


    //未来天气状况
    var state1=data.weatherinfo.temp2;
    document.getElementById("state1").innerHTML=state1;
    var perRange1=data.weatherinfo.weather2;
    document.getElementById("range1").innerHTML=perRange1;


    var perState2=data.weatherinfo.temp3;
    document.getElementById("perState2").innerHTML=perState2;
    var perRange2=data.weatherinfo.weather3;
    document.getElementById("perRange2").innerHTML=perRange2;


    var perState3=data.weatherinfo.temp4;
    document.getElementById("perState3").innerHTML=perState3;
    var perRange3=data.weatherinfo.weather4;
    document.getElementById("perRange3").innerHTML=perRange3;


    var perState4=data.weatherinfo.temp5;
    document.getElementById("perState4").innerHTML=perState4;
    var perRange4=data.weatherinfo.weather5;
    document.getElementById("perRange4").innerHTML=perRange4;

    var perState5=data.weatherinfo.temp6;
    document.getElementById("perState5").innerHTML=perState5;
    var perRange5=data.weatherinfo.weather6;
    document.getElementById("perRange5").innerHTML=perRange5;


    var purPicture1=data.weatherinfo.st2;
    var picUrl1="http://www.duba.com/static/v2/images/weather/a/a"+purPicture1+".png"
    document.getElementById("purPicture1").setAttribute('src',picUrl1);

    var purPicture2=data.weatherinfo.st3;
    var picUrl2="http://www.duba.com/static/v2/images/weather/a/a"+purPicture2+".png"
    document.getElementById("purPicture2").setAttribute('src',picUrl2);

    var purPicture3=data.weatherinfo.st4;
    var picUrl3="http://www.duba.com/static/v2/images/weather/a/a"+purPicture3+".png"
    document.getElementById("purPicture3").setAttribute('src',picUrl3);

    var purPicture4=data.weatherinfo.st5;
    var picUrl4="http://www.duba.com/static/v2/images/weather/a/a"+purPicture4+".png"
    document.getElementById("purPicture4").setAttribute('src',picUrl4);

    var purPicture5=data.weatherinfo.st6;
    var picUrl5="http://www.duba.com/static/v2/images/weather/a/a"+purPicture5+".png"
    document.getElementById("purPicture5").setAttribute('src',picUrl5);
}

