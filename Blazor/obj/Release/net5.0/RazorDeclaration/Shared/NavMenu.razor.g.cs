// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SEP3_Blazor.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using SEP3_Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\em_du\RiderProjects\SEP3\Blazor\_Imports.razor"
using Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\em_du\RiderProjects\SEP3\Blazor\Shared\NavMenu.razor"
using SEP3_Blazor.Data;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "C:\Users\em_du\RiderProjects\SEP3\Blazor\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;
    
    private string UserName;
    private string Password;
    private string errorMessage;


    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
    
    public async Task PerformLogout()
    {
        errorMessage = "";
        UserName = "";
        Password = "";
        try
        {
            //((AAuthenticationStateProvider) AuthenticationStateProvider).Logout();
            //NavigationManager.NavigateTo("/");
        }
        catch (Exception ){}
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
