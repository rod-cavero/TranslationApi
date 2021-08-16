# TranslationApi
### Version 1.0.0

A basic example of the google translate Api.
This is just a exmaple to test the api capabilities
***


Installation
====
```
docker pull ghcr.io/rod-cavero/translationapi:master
```
Note. Run the coteiner on port 5000
***


Swagger
```
http://localhost:5000/swagger/index.html
```
***


Basic Usage
====
```
localhost:5000/api/Translation?text=hello&target=de&source=en
```
QueryString:
* ***text The text to be translated
* ***target The target language for the trnaslation
* ***source The source language of the trnaslation (set 'auto' for auto detect language)
***


Prerequisites
====
* ***Microsoft .net core 5
***


License
====
google_trans_new is licensed under the MIT License. The terms are as follows:  

```
MIT License  

Copyright (c) 2020 lushan88a  

Permission is hereby granted, free of charge, to any person obtaining a copy  
of this software and associated documentation files (the "Software"), to deal  
in the Software without restriction, including without limitation the rights  
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell  
copies of the Software, and to permit persons to whom the Software is  
furnished to do so, subject to the following conditions:  

The above copyright notice and this permission notice shall be included in all  
copies or substantial portions of the Software.  

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR  
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,  
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE  
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER  
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,  
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE  
SOFTWARE.  
```
