﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppOperationResult"), OutputType(typeof(OperationResult))]
    public class GetAzureRemoteAppOperationResult : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "Operation Identifier")]

        public string TrackingId { get; set; }

        public override void ExecuteCmdlet()
        {
            RemoteAppOperationStatusResult response = null;

            response = CallClient(() => Client.OperationResults.Get(TrackingId), Client.OperationResults);

            if (response != null)
            {
                WriteObject(response.RemoteAppOperationResult);
            }

        }
    }
}
