/*
 * Copyright 2014, 2015 James Geall
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
/*
 * Copyright 2014, 2015 James Geall
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Linq;
using Thinktecture.IdentityServer.Core.Models;
using Thinktecture.IdentityServer.Core.Services;
using Xunit;

namespace Core.MongoDb.Tests
{
    public class ScopeSerializerMandatoryPropertiesShouldRoundTrip : PersistenceTest, IClassFixture<PersistenceTestFixture>
    {
        private Scope _expected;
        private Scope _actual;


        [Fact]
        public void ShouldNotBeNull()
        {
            Assert.NotNull(_actual);
        }

        [Fact]
        public void CheckName()
        {
            Assert.Equal(_expected.Name, _actual.Name);
        }

        [Fact]
        public void CheckClaimsRule()
        {
            Assert.Equal(_expected.ClaimsRule, _actual.ClaimsRule);
        }

        [Fact]
        public void CheckClaims()
        {
            Assert.Equal(_expected.Claims, _actual.Claims);
        }

        [Fact]
        public void CheckDescription()
        {
            Assert.Equal(_expected.Description, _actual.Description);
        }

        [Fact]
        public void CheckDisplayName()
        {
            Assert.Equal(_expected.DisplayName, _actual.DisplayName);
        }

        [Fact]
        public void CheckEmphasize()
        {
            Assert.Equal(_expected.Emphasize, _actual.Emphasize);
        }

        [Fact]
        public void CheckEnabled()
        {
            Assert.Equal(_expected.Enabled, _actual.Enabled);
        }

        [Fact]
        public void CheckIncludeAllClaimsForUser()
        {
            Assert.Equal(_expected.IncludeAllClaimsForUser, _actual.IncludeAllClaimsForUser);
        }

        [Fact]
        public void CheckRequired()
        {
            Assert.Equal(_expected.Required, _actual.Required);
        }

        [Fact]
        public void CheckShowInDiscoveryDocument()
        {
            Assert.Equal(_expected.ShowInDiscoveryDocument, _actual.ShowInDiscoveryDocument);
        }

        [Fact]
        public void CheckType()
        {
            Assert.Equal(_expected.Type, _actual.Type);
        }

        [Fact]
        public void CheckAll()
        {
            var serializer = new JsonSerializer() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var expected = JObject.FromObject(_expected, serializer).ToString();
            var actual = JObject.FromObject(_actual, serializer).ToString();
            Assert.Equal(expected, actual);
        }

        public ScopeSerializerMandatoryPropertiesShouldRoundTrip(PersistenceTestFixture data)
            : base(data)
        {
            _expected = TestData.ScopeMandatoryProperties();
            Save(_expected);
            _actual = Factory.Resolve<IScopeStore>().GetScopesAsync().Result.SingleOrDefault(x => x.Name == _expected.Name);

        }
    }
}