using RestAPICore20.Models.Interfaces;
using RestAPICore20.NoSQL.LiteDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPICore20.Models.Implements
{
    public class StateImplements : IStatable
    {
        private readonly INoSQLRepository<StateModel> NoSQLRepository;

        public StateImplements(INoSQLRepository<StateModel> noSQLRepository)
        {
            this.NoSQLRepository = noSQLRepository;
        }

        public StateModel ReadState(Guid Id)
        {
            //if (NoSQLRepository.Count(state => state.Id == Id) > 0)
                return NoSQLRepository.GetOne(state => state.Id == Id);

            //return null;
        }

        public bool SaveState(StateModel State)
        {
            if (NoSQLRepository.Count(state => state.Id == State.Id) > 0)
                return false;
            return NoSQLRepository.Save(State);
        }
        public IReadOnlyCollection<StateModel> ReadAll()
        {
            return NoSQLRepository.GetAll(state => state != null).ToList();
        }
    }
}
