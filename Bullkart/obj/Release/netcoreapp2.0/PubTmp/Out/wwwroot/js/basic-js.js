//Carries the functions used in the page
function words() {
	return document.body.innerText.split(' ');
};
function allTags() {
	return document.all;
};
function distinctTags() {
	var tags = allTags();
	var distinct = new Set(); //Use set to remove duplicates from the collection
	for(i=0; i<tags.length; i++){
		distinct.add(tags[i].tagName);
	}
	return distinct;	
};
function sortedTags(){
	return Array.from(distinctTags()).sort();
};
function popularTags(){
	var tags = allTags();
	var populartags = [];
	var map = {};
	for(i=0; i<tags.length; i++){
		map[tags[i].tagName] = map[tags[i].tagName] ? parseInt(map[tags[i].tagName])+1 : 1; 
	}
	for(var key in map){
		if(map[key] >= 4){
			populartags.push(key)
		}
		if(key == "div"){
			var inverttag = key;
		}
	}
	invertColors(inverttag);
	return populartags;
};
function populateResult(arg){
	document.getElementById("result").innerHTML = "Button Output : " + arg;
};
function invertColors(tag){
	var invertelement = document.getElementsByTagName(tag)[0];
	var forecolor = invertelement.color ? invertelement.color : "black";
	var backColor = invertelement.backgroundColor ? invertelement.backgroundColor : "white";
	invertelement.color = backColor;
	invertelement.backgroundColor = foreColor;
}
