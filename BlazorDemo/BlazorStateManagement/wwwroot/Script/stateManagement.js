function setLocalStorage(key, localValue)
{
    localStorage.setItem(key, JSON.stringify(localValue));
}

function getLocalStorage(key)
{
    var localValue = JSON.parse(localStorage.getItem(key));

    return localValue;
}