function RegisterEvent(Element)
{
    var ButtonElement = document.getElementById('AlertButton');
    ButtonElement.addEventListener("click", ShowAlert);

    Element.addEventListener('mouseover',
        function ChangeColorOnMouseOver()
        {
            Element.style.color = "chartreuse";
            Element.style.fontWeight = "bolder";
        });

    Element.addEventListener('mouseout',
        function ChangeColorToNormal()
        {
            Element.style.color = "black";
            Element.style.fontWeight = "normal";
        });
}

function ShowAlert()
{
    alert('Alert triggered from Button');
}