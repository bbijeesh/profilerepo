using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuildingBlocks.CQRS
{
    public interface ICommand<out TResponse> : IRequest<TResponse> { }

    public interface ICommand : ICommand<Unit> { }  

}
