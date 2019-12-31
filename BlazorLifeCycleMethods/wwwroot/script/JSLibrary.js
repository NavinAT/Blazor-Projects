function ShowAlert()
{
    var MyHeader = document.getElementById("MyHeader").innerHTML;

    document.getElementById("MyParagraph").innerHTML = MyHeader;

    alert(MyHeader);
}