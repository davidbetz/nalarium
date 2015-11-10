You do stuff enough you'll want to stop repeating yourself. Be DRY. This project is my desert.

* **Nalarium Core** is the main project; in fact Nalarium.dll is the soul. I add it to everything. It's my server-side crutch as much as [understore.js](http://underscorejs.org/) is my JavaScript crutch. It's on Nuget. [Go get it](https://www.nuget.org/packages/Nalarium/). It's the only part of Nalarium that really matters anymore.

### Totally out-of-context Nalarium.dll sample:
	
		var path = @"E:\Drive\Documents\Content\NetFX\NetFXContent\2009\06";
		var url = Url.FromPath(path);
		var ultima = Url.GetPart(context, Position.Penultima);
		//+ ultimate == 2009
