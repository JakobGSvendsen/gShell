// gShell is licensed under the GNU GENERAL PUBLIC LICENSE, Version 3
//
// http://www.gnu.org/licenses/gpl-3.0.en.html
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
//
// gShell is based upon https://github.com/google/google-api-dotnet-client, which is licensed under the Apache 2.0
// license: https://github.com/google/google-api-dotnet-client/blob/master/LICENSE
//
// gShell is reliant upon the Google Apis. Please see the specific API pages for specific licensing information.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a fork of google-apis-code-generator:
//       https://github.com/squid808/apis-client-generator
//
//     How neat is that? Pretty neat.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gShell.Cmdlets.Reports{

    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using reports_v1 = Google.Apis.admin.Reports.reports_v1;
    using Data = Google.Apis.admin.Reports.reports_v1.Data;

    using gShell.dotNet.Utilities;
    using gShell.dotNet.Utilities.OAuth2;
    using gReports = gShell.dotNet.Reports;

    /// <summary>
    /// A PowerShell-ready wrapper for the Reports api, as well as the resources and methods therein.
    /// </summary>
    public abstract class ReportsBase : OAuth2CmdletBase
    {

        #region Properties

        /// <summary>
        /// <para type="description">The domain against which this cmdlet should run.</para>
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Domain { get; set; }

        /// <summary>The gShell dotNet class wrapper base.</summary>
        protected static gReports mainBase { get; set; }


        /// <summary>An instance of the Activities gShell dotNet resource.</summary>
        public Activities activities { get; set; }

        /// <summary>An instance of the Channels gShell dotNet resource.</summary>
        public Channels channels { get; set; }

        /// <summary>An instance of the CustomerUsageReports gShell dotNet resource.</summary>
        public CustomerUsageReports customerUsageReports { get; set; }

        /// <summary>An instance of the UserUsageReport gShell dotNet resource.</summary>
        public UserUsageReport userUsageReport { get; set; }

        /// <summary>Returns the api name and version in {name}:{version} format.</summary>
        protected override string apiNameAndVersion { get { return mainBase.apiNameAndVersion; } }

        /// <summary>Gets or sets the email account the gShell Service Account should impersonate.</summary>
        protected static string gShellServiceAccount { get; set; }
        #endregion

        #region Constructors
        protected ReportsBase()
        {
            mainBase = new gReports();

            activities = new Activities();
            channels = new Channels();
            customerUsageReports = new CustomerUsageReports();
            userUsageReport = new UserUsageReport();
        }
        #endregion

        #region PowerShell Methods
        /// <summary>The gShell base implementation of the PowerShell BeginProcessing method.</summary>
        /// <remarks>If a service account needs to be identified, it should be in a child class that overrides
        /// and calls this method.</remarks>
        protected override void BeginProcessing()
        {
            var secrets = CheckForClientSecrets();
            if (secrets != null)
            {
                IEnumerable<string> scopes = EnsureScopesExist(Domain);
                Domain = mainBase.BuildService(Authenticate(scopes, secrets, Domain), gShellServiceAccount).domain;

                GWriteProgress = new gWriteProgress(WriteProgress);
            }
            else
            {
                WriteError(new ErrorRecord(null, (new Exception(
                    "Client Secrets must be set before running cmdlets. Run 'Get-Help "
                    + "Set-gShellClientSecrets -online' for more information."))));
            }
        }

        /// <summary>The gShell base implementation of the PowerShell EndProcessing method.</summary>
        /// <remarks>We need to reset the service account after every Cmdlet call to prevent the next
        /// Cmdlet from inheriting it as well.</remarks>
        protected override void EndProcessing()
        {
            gShellServiceAccount = string.Empty;
        }

        /// <summary>The gShell base implementation of the PowerShell StopProcessing method.</summary>
        /// <remarks>We need to reset the service account after every Cmdlet call to prevent the next
        /// Cmdlet from inheriting it as well.</remarks>
        protected override void StopProcessing()
        {
            gShellServiceAccount = string.Empty;
        }
        #endregion

        #region Authentication & Processing
        /// <summary>Ensure the user, domain and client secret combination work with an authenticated user.</summary>
        /// <param name="Scopes">The scopes that need to be passed through to the user authentication to Google.</param>
        /// <param name="Secrets">The client secrets.`</param>
        /// <param name="Domain">The domain for which this authentication is intended.</param>
        /// <returns>The AuthenticatedUserInfo for the authenticated user.</returns>
        protected override AuthenticatedUserInfo Authenticate(IEnumerable<string> Scopes, ClientSecrets Secrets, string Domain = null)
        {
            return mainBase.Authenticate(apiNameAndVersion, Scopes, Secrets, Domain);
        }
        #endregion

        #region Wrapped Methods



        #region Activities

        /// <summary>A wrapper class for the Activities resource.</summary>
        public class Activities
        {




            /// <summary>Retrieves a list of activities for a specific customer and application.</summary>
            /// <param name="UserKey">Represents the profile id or the user email for which the data should be filtered. When 'all'
            /// is specified as the userKey, it returns usageReports for all users.</param>
            /// <param
            /// name="ApplicationName">Application name for which the events are to be retrieved.</param>
            /// <param name="properties">The optional properties for this method.</param>

            public List<Google.Apis.admin.Reports.reports_v1.Data.Activities> List(string UserKey, string ApplicationName, gReports.Activities.ActivitiesListProperties properties= null)
            {

                properties = properties ?? new gReports.Activities.ActivitiesListProperties();
                properties.StartProgressBar = StartProgressBar;
                properties.UpdateProgressBar = UpdateProgressBar;

                return mainBase.activities.List(UserKey, ApplicationName, properties);
            }

            /// <summary>Push changes to activities</summary>
            /// <param name="ChannelBody">The body of the request.</param>
            /// <param name="UserKey">Represents the profile id or the user email for which the data should be filtered. When 'all'
            /// is specified as the userKey, it returns usageReports for all users.</param>
            /// <param
            /// name="ApplicationName">Application name for which the events are to be retrieved.</param>
            /// <param name="properties">The optional properties for this method.</param>
            public Google.Apis.admin.Reports.reports_v1.Data.Channel Watch (Google.Apis.admin.Reports.reports_v1.Data.Channel ChannelBody, string UserKey, string ApplicationName, gReports.Activities.ActivitiesWatchProperties properties= null)
            {

                properties = properties ?? new gReports.Activities.ActivitiesWatchProperties();

                return mainBase.activities.Watch(ChannelBody, UserKey, ApplicationName, properties, gShellServiceAccount);
            }


        }
        #endregion



        #region Channels

        /// <summary>A wrapper class for the Channels resource.</summary>
        public class Channels
        {




            /// <summary>Stop watching resources through this channel</summary>
            /// <param name="ChannelBody">The body of the request.</param>
            public void Stop (Google.Apis.admin.Reports.reports_v1.Data.Channel ChannelBody)
            {

                mainBase.channels.Stop(ChannelBody, gShellServiceAccount);
            }


        }
        #endregion



        #region CustomerUsageReports

        /// <summary>A wrapper class for the CustomerUsageReports resource.</summary>
        public class CustomerUsageReports
        {




            /// <summary>Retrieves a report which is a collection of properties / statistics for a specific
            /// customer.</summary>
            /// <param name="Date">Represents the date in yyyy-mm-dd format for which the data is to be fetched.</param>
            /// <param name="properties">The optional properties for this method.</param>

            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(string Date, gReports.CustomerUsageReports.CustomerUsageReportsGetProperties properties= null)
            {

                properties = properties ?? new gReports.CustomerUsageReports.CustomerUsageReportsGetProperties();


                return mainBase.customerUsageReports.Get(Date, properties);
            }
        }
        #endregion



        #region UserUsageReport

        /// <summary>A wrapper class for the UserUsageReport resource.</summary>
        public class UserUsageReport
        {




            /// <summary>Retrieves a report which is a collection of properties / statistics for a set of
            /// users.</summary>
            /// <param name="UserKey">Represents the profile id or the user email for which the data should be
            /// filtered.</param>
            /// <param name="Date">Represents the date in yyyy-mm-dd format for which the data is to be
            /// fetched.</param>
            /// <param name="properties">The optional properties for this method.</param>

            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(string UserKey, string Date, gReports.UserUsageReport.UserUsageReportGetProperties properties= null)
            {

                properties = properties ?? new gReports.UserUsageReport.UserUsageReportGetProperties();
                properties.StartProgressBar = StartProgressBar;
                properties.UpdateProgressBar = UpdateProgressBar;

                return mainBase.userUsageReport.Get(UserKey, Date, properties);
            }
        }
        #endregion

        #endregion

    }
}



namespace gShell.dotNet
{
    using System;
    using System.Collections.Generic;

    using gShell.dotNet;
    using gShell.dotNet.Utilities.OAuth2;

    using reports_v1 = Google.Apis.admin.Reports.reports_v1;
    using Data = Google.Apis.admin.Reports.reports_v1.Data;

    /// <summary>The dotNet gShell version of the admin api.</summary>
    public class Reports : ServiceWrapper<reports_v1.ReportsService>
    {

        protected override bool worksWithGmail { get { return false; } }

        /// <summary>Creates a new reports_v1.Reports service.</summary>
        /// <param name="domain">The domain to which this service will be authenticated.</param>
        /// <param name="authInfo">The authenticated AuthInfo for this user and domain.</param>
        /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>

        protected override reports_v1.ReportsService CreateNewService(string domain, AuthenticatedUserInfo authInfo, string gShellServiceAccount = null)
        {
            return new reports_v1.ReportsService(OAuth2Base.GetInitializer(domain, authInfo, gShellServiceAccount));
        }

        /// <summary>Returns the api name and version in {name}:{version} format.</summary>
        public override string apiNameAndVersion { get { return "admin:reports_v1"; } }


        /// <summary>Gets or sets the activities resource class.</summary>
        public Activities activities{ get; set; }

        /// <summary>Gets or sets the channels resource class.</summary>
        public Channels channels{ get; set; }

        /// <summary>Gets or sets the customerUsageReports resource class.</summary>
        public CustomerUsageReports customerUsageReports{ get; set; }

        /// <summary>Gets or sets the userUsageReport resource class.</summary>
        public UserUsageReport userUsageReport{ get; set; }

        public Reports()
        {

            activities = new Activities();
            channels = new Channels();
            customerUsageReports = new CustomerUsageReports();
            userUsageReport = new UserUsageReport();
        }



        /// <summary>The "activities" collection of methods.</summary>
        public class Activities
        {

            /// <summary>Optional parameters for the Activities List method.</summary>
            public class ActivitiesListProperties
            {
                /// <summary>IP Address of host where the event was performed. Supports both IPv4 and IPv6 addresses.</summary>
                public string ActorIpAddress = null;

                /// <summary>Represents the customer for which the data is to be fetched.</summary>
                public string CustomerId = null;

                /// <summary>Return events which occured at or before this time.</summary>
                public string EndTime = null;

                /// <summary>Name of the event being queried.</summary>
                public string EventName = null;

                /// <summary>Event parameters in the form [parameter1 name][operator][parameter1 value],[parameter2 name][operator][parameter2 value],...</summary>
                public string Filters = null;

                /// <summary>Number of activity records to be shown in each page.</summary>
                public int MaxResults = 1000;

                /// <summary>Return events which occured at or after this time.</summary>
                public string StartTime = null;

                /// <summary>A delegate that is used to start a progress bar.</summary>
                public Action<string, string> StartProgressBar = null;

                /// <summary>A delegate that is used to update a progress bar.</summary>
                public Action<int, int, string, string> UpdateProgressBar = null;

                /// <summary>A counter for the total number of results to pull when iterating through paged results.</summary>
                public int TotalResults = 0;
            }

            /// <summary>Optional parameters for the Activities Watch method.</summary>
            public class ActivitiesWatchProperties
            {
                /// <summary>IP Address of host where the event was performed. Supports both IPv4 and IPv6 addresses.</summary>
                public string ActorIpAddress = null;

                /// <summary>Represents the customer for which the data is to be fetched.</summary>
                public string CustomerId = null;

                /// <summary>Return events which occured at or before this time.</summary>
                public string EndTime = null;

                /// <summary>Name of the event being queried.</summary>
                public string EventName = null;

                /// <summary>Event parameters in the form [parameter1 name][operator][parameter1 value],[parameter2 name][operator][parameter2 value],...</summary>
                public string Filters = null;

                /// <summary>Number of activity records to be shown in each page.</summary>
                public int MaxResults = 1000;

                /// <summary>Return events which occured at or after this time.</summary>
                public string StartTime = null;
            }


            /// <summary>Retrieves a list of activities for a specific customer and application.</summary>
            /// <param name="UserKey">Represents the profile id or the user email for which the data should be filtered. When 'all'
            /// is specified as the userKey, it returns usageReports for all users.</param>
            /// <param
            /// name="ApplicationName">Application name for which the events are to be retrieved.</param>
            /// <param name="properties">The optional properties for this method.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public List<Google.Apis.admin.Reports.reports_v1.Data.Activities> List(
                string UserKey, string ApplicationName, ActivitiesListProperties properties= null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.admin.Reports.reports_v1.Data.Activities>();

                reports_v1.ActivitiesResource.ListRequest request = GetService(gShellServiceAccount).Activities.List(UserKey, ApplicationName);

                if (properties != null)
                {
                    request.ActorIpAddress = properties.ActorIpAddress;
                    request.CustomerId = properties.CustomerId;
                    request.EndTime = properties.EndTime;
                    request.EventName = properties.EventName;
                    request.Filters = properties.Filters;
                    request.MaxResults = properties.MaxResults;
                    request.StartTime = properties.StartTime;

                }

                if (null != properties.StartProgressBar)
                {
                    properties.StartProgressBar("Gathering Activities",
                        string.Format("-Collecting Activities 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Reports.reports_v1.Data.Activities pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.TotalResults == 0 || results.Count < properties.TotalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.UpdateProgressBar)
                        {
                            properties.UpdateProgressBar(5, 10, "Gathering Activities",
                                    string.Format("-Collecting Activities {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.UpdateProgressBar)
                    {
                        properties.UpdateProgressBar(1, 2, "Gathering Activities",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

            /// <summary>Push changes to activities</summary>
            /// <param name="ChannelBody">The body of the request.</param>
            /// <param name="UserKey">Represents the profile id or the user email for which the data should be filtered. When 'all'
            /// is specified as the userKey, it returns usageReports for all users.</param>
            /// <param
            /// name="ApplicationName">Application name for which the events are to be retrieved.</param>
            /// <param name="properties">The optional properties for this method.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public Google.Apis.admin.Reports.reports_v1.Data.Channel Watch (Google.Apis.admin.Reports.reports_v1.Data.Channel ChannelBody, string UserKey, string ApplicationName, ActivitiesWatchProperties properties= null, string gShellServiceAccount = null)
            {
                return GetService(gShellServiceAccount).Activities.Watch(ChannelBody, UserKey, ApplicationName).Execute();
            }

        }

        /// <summary>The "channels" collection of methods.</summary>
        public class Channels
        {




            /// <summary>Stop watching resources through this channel</summary>
            /// <param name="ChannelBody">The body of the request.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public void Stop (Google.Apis.admin.Reports.reports_v1.Data.Channel ChannelBody, string gShellServiceAccount = null)
            {
                GetService(gShellServiceAccount).Channels.Stop(ChannelBody).Execute();
            }

        }

        /// <summary>The "customerUsageReports" collection of methods.</summary>
        public class CustomerUsageReports
        {

            /// <summary>Optional parameters for the CustomerUsageReports Get method.</summary>
            public class CustomerUsageReportsGetProperties
            {
                /// <summary>Represents the customer for which the data is to be fetched.</summary>
                public string CustomerId = null;

                /// <summary>Represents the application name, parameter name pairs to fetch in csv as app_name1:param_name1, app_name2:param_name2.</summary>
                public string Parameters = null;

                /// <summary>A delegate that is used to start a progress bar.</summary>
                public Action<string, string> StartProgressBar = null;

                /// <summary>A delegate that is used to update a progress bar.</summary>
                public Action<int, int, string, string> UpdateProgressBar = null;

                /// <summary>A counter for the total number of results to pull when iterating through paged results.</summary>
                public int TotalResults = 0;
            }


            /// <summary>Retrieves a report which is a collection of properties / statistics for a specific
            /// customer.</summary>
            /// <param name="Date">Represents the date in yyyy-mm-dd format for which the data is to be fetched.</param>
            /// <param name="properties">The optional properties for this method.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(
                string Date, CustomerUsageReportsGetProperties properties= null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports>();

                reports_v1.CustomerUsageReportsResource.GetRequest request = GetService(gShellServiceAccount).CustomerUsageReports.Get(Date);

                if (properties != null)
                {
                    request.CustomerId = properties.CustomerId;
                    request.Parameters = properties.Parameters;

                }

                if (null != properties.StartProgressBar)
                {
                    properties.StartProgressBar("Gathering CustomerUsageReports",
                        string.Format("-Collecting CustomerUsageReports 1 to {0}", "unknown"));
                }

                Google.Apis.admin.Reports.reports_v1.Data.UsageReports pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.TotalResults == 0 || results.Count < properties.TotalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.UpdateProgressBar)
                        {
                            properties.UpdateProgressBar(5, 10, "Gathering CustomerUsageReports",
                                    string.Format("-Collecting CustomerUsageReports {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        "unknown"));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.UpdateProgressBar)
                    {
                        properties.UpdateProgressBar(1, 2, "Gathering CustomerUsageReports",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }

        /// <summary>The "userUsageReport" collection of methods.</summary>
        public class UserUsageReport
        {

            /// <summary>Optional parameters for the UserUsageReport Get method.</summary>
            public class UserUsageReportGetProperties
            {
                /// <summary>Represents the customer for which the data is to be fetched.</summary>
                public string CustomerId = null;

                /// <summary>Represents the set of filters including parameter operator value.</summary>
                public string Filters = null;

                /// <summary>Maximum number of results to return. Maximum allowed is 1000</summary>
                public int MaxResults = 1000;

                /// <summary>Represents the application name, parameter name pairs to fetch in csv as app_name1:param_name1, app_name2:param_name2.</summary>
                public string Parameters = null;

                /// <summary>A delegate that is used to start a progress bar.</summary>
                public Action<string, string> StartProgressBar = null;

                /// <summary>A delegate that is used to update a progress bar.</summary>
                public Action<int, int, string, string> UpdateProgressBar = null;

                /// <summary>A counter for the total number of results to pull when iterating through paged results.</summary>
                public int TotalResults = 0;
            }


            /// <summary>Retrieves a report which is a collection of properties / statistics for a set of
            /// users.</summary>
            /// <param name="UserKey">Represents the profile id or the user email for which the data should be
            /// filtered.</param>
            /// <param name="Date">Represents the date in yyyy-mm-dd format for which the data is to be
            /// fetched.</param>
            /// <param name="properties">The optional properties for this method.</param>
            /// <param name="gShellServiceAccount">The optional email address the service account should impersonate.</param>
            public List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports> Get(
                string UserKey, string Date, UserUsageReportGetProperties properties= null, string gShellServiceAccount = null)
            {
                var results = new List<Google.Apis.admin.Reports.reports_v1.Data.UsageReports>();

                reports_v1.UserUsageReportResource.GetRequest request = GetService(gShellServiceAccount).UserUsageReport.Get(UserKey, Date);

                if (properties != null)
                {
                    request.CustomerId = properties.CustomerId;
                    request.Filters = properties.Filters;
                    request.MaxResults = properties.MaxResults;
                    request.Parameters = properties.Parameters;

                }

                if (null != properties.StartProgressBar)
                {
                    properties.StartProgressBar("Gathering UserUsageReport",
                        string.Format("-Collecting UserUsageReport 1 to {0}", request.MaxResults.ToString()));
                }

                Google.Apis.admin.Reports.reports_v1.Data.UsageReports pagedResult = request.Execute();

                if (pagedResult != null)
                {
                    results.Add(pagedResult);

                    while (!string.IsNullOrWhiteSpace(pagedResult.NextPageToken) &&
                        pagedResult.NextPageToken != request.PageToken &&
                    (properties.TotalResults == 0 || results.Count < properties.TotalResults))
                    {
                        request.PageToken = pagedResult.NextPageToken;

                        if (null != properties.UpdateProgressBar)
                        {
                            properties.UpdateProgressBar(5, 10, "Gathering UserUsageReport",
                                    string.Format("-Collecting UserUsageReport {0} to {1}",
                                        (results.Count + 1).ToString(),
                                        (results.Count + request.MaxResults).ToString()));
                        }
                        pagedResult = request.Execute();
                        results.Add(pagedResult);
                    }

                    if (null != properties.UpdateProgressBar)
                    {
                        properties.UpdateProgressBar(1, 2, "Gathering UserUsageReport",
                                string.Format("-Returning {0} results.", results.Count.ToString()));
                    }
                }

                return results;
            }

        }

    }
}