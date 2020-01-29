function JSMethod()
{
    DotNet.invokeMethodAsync('BlazorAppJavaScriptInterop', 'CSCallBackMethod');
}


function CallCSharpInstanceMethod(dotnetInstance)
{
    return dotnetInstance.invokeMethodAsync("IncrementCount")
        .then(result => console.log(result));
}