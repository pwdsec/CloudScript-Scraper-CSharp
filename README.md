<h1  align="center">
    CloudScript Scraper C#
    <h4 align="center">Working as of: - 3/27/2021</h4>
    <br>
</h1>

Takes less codes in C# than C++ so why not. It gets the Lua Script in Base64 Decode it and then show the source. It will also create a folder "Script" and put all the sources there that you have checked. I added bruteforce too but low-key useless. Just go here: <a href="https://lynx.rip/dashboard/home/cloudscripts/storage/">cloudscripts/storage/</a> you will have access to all the codes.

You will get an output like this:

```lua example
local a = "hello world"
print(a)
```
Instead of this:
```c example
bG9jYWwgYSA9ICJoZWxsbyB3b3JsZCIKcHJpbnQoYSk=
```

</br>

* ##### ChangeLogs:
  * ##### <b>[4/10/2021]:</b>
    * Throw Exception!!??
    * Changed some codes again.
    * Added some codes and formated.
  * ##### <b>[4/9/2021]:</b>
    * Formated the code.
    * Changed a bit the stuff.
    * Shitty {Not Found} handler.
    * Made it work with `cloudscript(0000000)()` it will just remove `cloudscript()()` and keep the int
  * ##### <b>[X/X/XXX]:</b>
    * Bruteforce. 
    * Cloudscript scrapper.
    * Start of the project. 
