using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyGame.Services.Interfaces;

public interface ICryptographyService
{
    public string GetSHA256HashString(string? input);
}
