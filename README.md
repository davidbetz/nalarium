You do stuff enough you'll want to stop repeating yourself. You'll want to be DRY. This is my desert.

I add my regularly and common stuff to Nalarium. It's my .NET crutch as much as [understore.js](http://underscorejs.org/) is my crutch in the browser

### Nuget

[Get it on Nuget](https://www.nuget.org/packages/Nalarium/)

### Totally out-of-context Nalarium.dll sample:

    var path = @"E:\Drive\Documents\Content\NetFX\NetFXContent\2009\06";
    var url = Url.FromPath(path);
    var ultima = Url.GetPart(context, Position.Penultima);
    //+ ultimate == 2009

Unit tests act as practical documentation. For example:


    public void ParseBoolean()
    {
      Assert.IsTrue(Nalarium.Parser.ParseBoolean(1));
      Assert.IsTrue(Nalarium.Parser.ParseBoolean("1"));
      Assert.IsTrue(Nalarium.Parser.ParseBoolean("1.0"));
      Assert.IsTrue(Nalarium.Parser.ParseBoolean("true"));
      Assert.IsTrue(Nalarium.Parser.ParseBoolean("True"));
      Assert.IsTrue(Nalarium.Parser.ParseBoolean("active"));
      Assert.IsTrue(Nalarium.Parser.ParseBoolean("on"));
      Assert.IsFalse(Nalarium.Parser.ParseBoolean("12"));
      Assert.IsFalse(Nalarium.Parser.ParseBoolean(12));
    }

  and

    public void Decompose()
    {
      var results = Nalarium.Binary.Decompose(12345);

      var expected = new List<long>(new long[] { 1, 8, 16, 32, 4096, 8192 });

      CollectionAssert.AreEqual(expected, results);
    }
