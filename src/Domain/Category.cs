﻿using Microsoft.AspNetCore.Components.Web;

namespace IWantApp.Domain;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active{ get; set; }
}