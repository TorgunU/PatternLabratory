using System;

public interface ITradeable
{
    public void Request();

    public event Action<int> RequestTrade;
}
