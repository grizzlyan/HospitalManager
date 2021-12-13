using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Helpers
{
    public class ModelListMapper<TResult, TList>
    {
        private readonly IMapper _mapper;

        public ModelListMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<TResult> MapModelList(IEnumerable<TList> incomingList)
        {
            var resultList = new List<TResult>();

            foreach (var item in incomingList)
            {
                var model = _mapper.Map<TResult>(item);
                resultList.Add(model);
            }

            return resultList;
        }
    }
}
