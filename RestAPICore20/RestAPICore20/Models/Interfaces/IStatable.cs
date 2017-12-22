using System;
using System.Collections.Generic;

namespace RestAPICore20.Models.Interfaces
{
    public interface IStatable
    {
        StateModel ReadState(Guid Id);
        bool SaveState(StateModel State);
        IReadOnlyCollection<StateModel> ReadAll();
    }
}
