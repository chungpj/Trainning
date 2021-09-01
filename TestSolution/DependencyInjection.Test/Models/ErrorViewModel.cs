// Copyright (c) ChungNA - 2020 All Rights Reserved
using System;

namespace DependencyInjection.Test.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
