using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace PNN.Identity;
public class SimpleAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultTokenHeader = "Authentication";
    public const string DefaultScheme = "SimpleAuthenticationScheme";
    public string TokenHeaderName { get; set; } = DefaultTokenHeader;
}
