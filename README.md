ApePI
=====

Library for creating a HTTP API that is based on your class model.

The API would be created from the class model as follows:

``` CSharp
// Root /
[NoStop]
public sealed class Root
{
    // /players will try to return the Players object,
    // but it can't because of the NoStop attribute on the class
    public Players Players { get; private set; }
    
    // /settings will return the Settings object - public GET and authorized POST
    // Can either be POSTed as Settings object or individual settings (name, etc.)
    public Settings Settings { get; internal set; }
}

// NoStop tells it that it can't be returned directly
[NoStop]
public sealed partial class Players
{
    // Key = player.Login
    private Dictionary<string, Player> playersL;
    
    // Key = player.Id
    private Dictionary<uint, Player> playersI;
    
    // /players/{login} will return a Player object - public GET only
    public Player this[string login]
    {
        get { return playersL[login]; }
    }
    
    // /players/{id} will return a Player object - public GET only
    public Player this[uint id]
    {
        get { return playersI[id]; }
    }
}

// Player object ( /players/{(login|id)} )
[JsonObject]
public sealed class Player
{
    // /players/{(login|id)}/login will return the player login - public GET only
    public string Login { get; private set; }
    
    // /players/{(login|id)}/id will return the player id - public GET only
    public uint Id { get; private set; }
    
    // /players/{login}/banned will return whether the player is banned
    // - public GET and authorized POST
    public bool Banned { get; internal set; }
}

// Settings object ( /settings )
[JsonObject]
public sealed class Settings
{
    // /settings/name will return the name - public GET and authorized POST
    public string Name { get; internal set; }
    
    // /settings/maxplayers will return the max players - public GET and authorized POST
    public uint MaxPlayers { get; internal set; }
}
```

All parts of the path that are based on the classes are case insensitive and parameters depend on their implementation.

Query/Post parameters could be used for functions:

``` CSharp
public sealed partial class Players
{
    // /players/all?offset=0&length=20 will return the first 20 players - public GET (authorized GET when internal)
    // POST would be PostAll, etc.
    public IEnumerable<Player> GetAll(uint offset, uint length)
    {
        return playersI.Skip(offset).Take(length);
    }
}
```
