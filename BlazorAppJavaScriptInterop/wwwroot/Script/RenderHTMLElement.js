function CreateDynamicHTMLElement()
{
    var dynamicElement = document.createElement("h5");
    dynamicElement.innerHTML = "This Element created from JS Interop with styles";
    dynamicElement.setAttribute('style', "color: darkseagreen; font-weight:bolder");
    document.getElementById('DivContainer').appendChild(dynamicElement);
}