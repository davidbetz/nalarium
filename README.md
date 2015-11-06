You do stuff enough you'll want to stop repeating yourself. Be DRY. This project is my desert.

* **Nalarium Core** is the main project; in fact Nalarium.dll is the soul. I add it to everything. It's my server-side crutch as much as [understore.js](http://underscorejs.org/) is my JavaScript crutch. It's on Nuget. [Go get it](https://www.nuget.org/packages/Nalarium/). It's the only part of Nalarium that really matters anymore.

### Totally out-of-context Nalarium.dll sample:
	
		var path = @"E:\Drive\Documents\Content\NetFX\NetFXContent\2009\06";
		var url = Url.FromPath(path);
		var ultima = Url.GetPart(context, Position.Penultima);
		//+ ultimate == 2009

* **Nalarium Client (historical)** is largely deprecated; ASP.NET's bundling and minification and MVC completely replaced it for me. This was for WebForms. This would gather up all your CSS and JS files from all sources everywhere and streamline them into a single place (either at the end of the page in a cust om OnDomLoad location or whatever). It would even suck resources out of DLLs for you. There were also providers to abstract the differences between jQuery and Prototype. Well, since jQuery (may it now [RIP](https://angularjs.org/)) won... that's moot.

* **Nalarium Web** is split into two parts:

  * Nalarium.Web (and some other parts): A lot of stuff just to smoother over web-related functionality. Because the web isn't... just web... and more (e.g. URLs aren't considered to be owned by the web), some stuff actually got promoted to Nalarium.dll (e.g. Url). A lot of stuff is historical, including my own version of WebAPI before Microsoft released theirs. Localization plays an important role in all page related things. Haven't touched it in years.

 
  * Nalarium.Web.Processing (aka **Themelia**; **historical**) - now defunct project about proved me mad in 2008. It's the largest things I've ever worked on. *It's ASP.NET on crack* (a concept inspired by my [collegue/mentor](https://github.com/Grimace1975)). I threw the [Themelia Pro website up on Azure](http://themeliapro.azurewebsites.net/) just for historical purposes. All the docs are there. I didn't update all the images. Don't care. Anyway: everything ran through a master HTTP module brain. You could define a website, then inherit one site from another (multi-tenancy through OOP XML config). You controlled your website via a surface area (i.e. white-listing): You controlled how you wanted your site to be accessed; locked down by default. Want /contact? Define it. It also ran off "web domains" (like app domains, but for your web site; think of lightweight virtual applications.) Then there was the component model (programmatic packages of stuff analagous to the following XML). It was crazy huge. I wanted to reinvent web development. About lost my mind in the process...Just for fun, below was one website's config file:

### Totally random Themelia Pro sample
  
<pre>
  &lt;web.processing&gt;
    &lt;webDomains&gt;
        &lt;add default="/Page_/Home/Root.aspx" catchAllMode="RedirectToRoot"&gt;
            &lt;endpoints&gt;
                &lt;add text="purchase" type="Page" parameter="/Page_/Home/Purchase.aspx" /&gt;
                &lt;add text="howto" type="Page" parameter="/Page_/Home/HowTo.aspx" /&gt;
                &lt;!----&gt;
                &lt;add text="sample/" type="Sequence" parameter="{Sample}" /&gt;
                &lt;add text="account" type="Sequence" parameter="{Account}" /&gt;
                &lt;add text="license" type="Sequence" parameter="{License}" /&gt;
                &lt;add text="register" type="Sequence" parameter="{Register}" /&gt;
                &lt;add text="support" type="Sequence" parameter="{Contact}" /&gt;
                &lt;add text="problem" type="Sequence" parameter="{Contact}" /&gt;
                &lt;add text="contact" type="Sequence" parameter="{Contact}" /&gt;
                &lt;add text="verify" type="Sequence" parameter="{Verification}" /&gt;
                &lt;!----&gt;
                &lt;add text="license/info" type="Page" parameter="/Page_/License/Info.aspx" /&gt;
                &lt;add text="register/check" type="Registration" /&gt;
                &lt;add selector="EndsWith" text="emailsend/" type="EmailProcessing" /&gt;
            &lt;/endpoints&gt;
            &lt;factories&gt;
                &lt;add type="NalariumWS.Web.Processing.HandlerFactory, NalariumWS.Web" /&gt;
            &lt;/factories&gt;
            &lt;security defaultAccessMode="Allow"
                      loginText="login"
                      loginPage="/Page_/Security/Login.aspx"
                      defaultLoggedInTarget="/"
                      validatorType="NalariumWS.Web.Security.SecurityValidator, NalariumWS.Web"&gt;
                &lt;exceptions&gt;
                    &lt;add key="account" /&gt;
                    &lt;!--&lt;add key="contact" /&gt;--&gt;
                    &lt;add key="support" /&gt;
                    &lt;add key="license" /&gt;
                &lt;/exceptions&gt;
            &lt;/security&gt;
        &lt;/add&gt;
        &lt;add default="{Sample}" name="SimpleContent" path="sample/simplecontent"&gt;
            &lt;endpoints&gt;
                &lt;add text="process" type="NalariumWS.Web.DownloadHttpHandler, NalariumWS.Web"&gt;
                    &lt;parameters&gt;
                        &lt;add name="FilePath" value="C:\_REFERENCE\PUBLIC\JampadTechnologySimpleContentViewer.zip" /&gt;
                        &lt;add name="OutputName" value="JampadTechnologySimpleContentViewer.zip" /&gt;
                        &lt;add name="ContentType" value="application/zip" /&gt;
                        &lt;add name="Size" value="31036" /&gt;
                    &lt;/parameters&gt;
                &lt;/add&gt;
            &lt;/endpoints&gt;
            &lt;!--&lt;accessRules&gt;
                &lt;add type="HttpReferrer" text="{blank}" actionType="Write" parameter="" /&gt;
            &lt;/accessRules&gt;--&gt;
        &lt;/add&gt;
        &lt;add default="/Page_/Home/Download.aspx" name="Download" path="download"&gt;
            &lt;endpoints&gt;
                &lt;add text="process" type="NalariumWS.Web.DownloadHttpHandler, NalariumWS.Web"&gt;
                    &lt;parameters&gt;
                        &lt;add name="FilePath" value="C:\_REFERENCE\RELEASE\Beta1\ThemeliaPro.Beta1.zip" /&gt;
                        &lt;add name="OutputName" value="ThemeliaPro.Beta1.zip" /&gt;
                        &lt;add name="ContentType" value="application/zip" /&gt;
                        &lt;add name="Size" value="271509" /&gt;
                    &lt;/parameters&gt;
                &lt;/add&gt;
                &lt;add type="File" text="source/lib/trace-latest.js"&gt;
                    &lt;parameters&gt;
                        &lt;add name="target" value="/Resource_/Source/Client/Lib/Trace-1.5.js" /&gt;
                        &lt;add name="extra" value="text/javascript" /&gt;
                    &lt;/parameters&gt;
                &lt;/add&gt;
            &lt;/endpoints&gt;
            &lt;!--&lt;accessRules&gt;
                &lt;add type="HttpReferrer" text="{blank}" actionType="Write" parameter="" /&gt;
            &lt;/accessRules&gt;--&gt;
        &lt;/add&gt;
        &lt;add name="ImageRendering" path="image/render/download" default="{Handler NalariumWS.Web.TextRenderHttpHandler, NalariumWS.Web}"&gt;
            &lt;parameters&gt;
                &lt;add name="ImageName" value="NalariumWS.Web._RESOURCE.Image.Download.png" /&gt;
                &lt;add name="Text" value="Version 2.0 Beta 1" /&gt;
                &lt;add name="TextColor" value="#ffffff" /&gt;
                &lt;add name="TopPosition" value="32" /&gt;
                &lt;add name="LeftPosition" value="87" /&gt;
                &lt;add name="FontFamily" value="Calibri, Arial" /&gt;
                &lt;add name="FontSize" value="12" /&gt;
            &lt;/parameters&gt;
            &lt;!--&lt;accessRules&gt;
                &lt;add type="HttpReferrer" text="{blank}" actionType="Write" parameter="" /&gt;
            &lt;/accessRules&gt;--&gt;
        &lt;/add&gt;
        &lt;add name="forum" path="forum" default="/Sequence_/Forum.aspx" catchAllMode="PassToDefault"&gt;
            &lt;components&gt;
                &lt;add type="Nalarium.Content.Processing.ContentComponent, Nalarium.Content"&gt;
                    &lt;parameters&gt;
                        &lt;add name="domainGuid" value="9A04ACDC-55B9-4085-9FAD-A913FBC29324" /&gt;
                    &lt;/parameters&gt;
                &lt;/add&gt;
            &lt;/components&gt;
            &lt;security defaultAccessMode="Block"
                      loginText="login"
                      loginPage="/Page_/Security/Login.aspx"
                      defaultLoggedInTarget="/forum/"
                      validatorType="NalariumWS.Web.Security.SecurityValidator, NalariumWS.Web" /&gt;
        &lt;/add&gt;
        &lt;add name="blog" path="blog" default="{Blog}" catchAllMode="PassToDefault"&gt;
            &lt;!--&lt;components&gt;
        &lt;add type="Jampad.SimpleContent.Processing.ContentComponent, Jampad.SimpleContent"&gt;
          &lt;parameters&gt;
            &lt;add name="physicalFolder" value="{AppSetting docsPhysicalFolder}" /&gt;
          &lt;/parameters&gt;
        &lt;/add&gt;
      &lt;/components&gt;--&gt;
        &lt;/add&gt;
        &lt;add name="docs" path="docs" default="{Documentation}" catchAllMode="PassToDefault"&gt;
            &lt;components&gt;
                &lt;add type="Jampad.SimpleContent.Processing.ContentComponent, Jampad.SimpleContent"&gt;
                    &lt;parameters&gt;
                        &lt;add name="physicalFolder" value="{AppSetting docsPhysicalFolder}" /&gt;
                    &lt;/parameters&gt;
                &lt;/add&gt;
            &lt;/components&gt;
        &lt;/add&gt;
        &lt;add name="reference" path="reference" default="{Documentation}" catchAllMode="PassToDefault"&gt;
            &lt;!--&lt;components&gt;
        &lt;add type="Jampad.SimpleContent.Processing.ContentComponent, Jampad.SimpleContent"&gt;
          &lt;parameters&gt;
            &lt;add name="physicalFolder" value="{AppSetting referencePhysicalFolder}" /&gt;
          &lt;/parameters&gt;
        &lt;/add&gt;
      &lt;/components&gt;--&gt;
        &lt;/add&gt;
    &lt;/webDomains&gt;
    &lt;!--&lt;sequences&gt;
        &lt;add name="Register"&gt;
            &lt;views&gt;
                &lt;add name="Input" /&gt;
                &lt;add name="VerificationSent" /&gt;
                &lt;add name="VerificationSuccess" /&gt;
                &lt;add name="VerificationError" /&gt;
            &lt;/views&gt;
        &lt;/add&gt;
    &lt;/sequences&gt;--&gt;
&lt;/web.processing&gt;
</pre>

## Totally random ACL sample

<pre>
&lt;accessRule&gt;
    &lt;rules&gt;
        &lt;!--+ write text on host --&gt;
        &lt;add group="test" action="{Write Hmmm}" condition="{Host 67.199.52.87}" /&gt;
        &lt;add group="test" action="Permit" /&gt;
        &lt;!--+ allow only one host --&gt;
        &lt;add group="test2" action="Permit" condition="{Host 72.47.154.93}" /&gt;
        &lt;add group="test2" action="{Write Hmmm}" condition="{Range 72.47.154.90-72.47.154.95}" /&gt;
        &lt;!--&lt;add group="test2" action="{Write Hadsfmmm}" condition="{MaskArea 72.47.154.0 0.0.0.255}" /&gt;--&gt;
        &lt;add group="test2" action="Permit" /&gt;
        &lt;!--+ no output when no http referrer--&gt;
        &lt;add group="antiLeech" action="{Write}" condition="{HttpReferrer}" /&gt;
        &lt;add group="antiLeech" action="Permit" /&gt;
        &lt;!--+ block anyone using IE6; even then only allow people with 10.1.x.x addressing access a specific IP address--&gt;
        &lt;add group="restrict" action="{Redirect http://www.getfirefox.com/}" condition="{UserAgent Mozilla}" /&gt;
        &lt;add group="restrict" action="Permit"&gt;
            &lt;composite&gt;
                &lt;add usage="from" value="{MaskArea 10.1.0.0 255.255.0.0}" /&gt;
                &lt;add usage="to" value="{Host 67.99.12.192}" /&gt;
                &lt;add value="{Subdomain www}" /&gt;
            &lt;/composite&gt;
        &lt;/add&gt;
        &lt;add group="restrict" action="{Write Dude}" /&gt;
        &lt;!--+ call the MyCustomConditionExecutor class; run EmailActionExecutor custom action --&gt;
        &lt;add group="customActionNotify" action="{Custom Email}" condition="{Custom MyCustom}" /&gt;
        &lt;add group="customActionNotify" action="Permit" /&gt;
        &lt;!--+ simply add a watcher --&gt;
        &lt;add group="watch" action="None" condition="{Custom MyCustom}" /&gt;
    &lt;/rules&gt;
&lt;/accessRule&gt;
</pre>
