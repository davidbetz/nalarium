You do stuff enough you'll want to stop repeating yourself. You'll want to be DRY. This is my desert.

I add my regularly and common stuff to Nalarium. It's my server-side crutch as much as [understore.js](http://underscorejs.org/) is my JavaScript crutch.

### Nuget

[Get it on Nuget](https://www.nuget.org/packages/Nalarium/)


### Totally out-of-context Nalarium.dll sample:
	
		var path = @"E:\Drive\Documents\Content\NetFX\NetFXContent\2009\06";
		var url = Url.FromPath(path);
		var ultima = Url.GetPart(context, Position.Penultima);
		//+ ultimate == 2009
