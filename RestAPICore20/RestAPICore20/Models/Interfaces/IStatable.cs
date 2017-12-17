using System;

namespace RestAPICore20.Models.Interfaces
{
    public interface IStatable
    {
        StateModel ReadState(Guid Id);
        bool SaveState(StateModel State);
    }
}
