using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts;

public interface IRepository
{
    void SetToken(string token);
    void SetUrl(string url);
    IProducts Products { get; }
    ICart Cart { get; }
    IUser User { get; }
    ILogin Login { get; }
}
