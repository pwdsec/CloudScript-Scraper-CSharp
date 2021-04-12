# CloudScript Scraper C#
CloudScript Scraper made in c#

Takes less codes in C# than C++ so why not. It gets the Lua Script in Base64 Decode it and then show the source. It will also create a folder "Script" and put all the sources there that you have checked. I added bruteforce too but low-key useless: just go here: <a href="https://lynx.rip/dashboard/home/cloudscripts/storage/">cloudscripts/storage/</a> you will have access to all the codes.

you will get an output like this:

```lua example
local a = "hello world"
print(a)
```
instead of this:
```c example
bG9jYWwgYSA9ICJoZWxsbyB3b3JsZCIKcHJpbnQoYSk=
```

</br>

* ChangeLogs:
  * <b>[4/10/2021]:</b>
    * Throw Exception!!??
    * Changed some codes again.
    * Added some codes and formated.
  * <b>[4/9/2021]:</b>
    * Formated the code.
    * Changed a bit the stuff.
    * Shitty {Not Found} handler.
    * Made it work with `cloudscript(0000000)()` it will just remove `cloudscript()()` and keep the int
  * <b>[X/X/XXX]:</b>
    * Bruteforce. 
    * Cloudscript scrapper.
    * Start of the project. 