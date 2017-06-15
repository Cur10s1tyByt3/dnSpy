﻿/*
    Copyright (C) 2014-2017 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;

namespace dnSpy.Debugger.DotNet.Metadata.Impl {
	sealed class DmdNullGlobalType : DmdTypeDef {
		public override DmdModule Module { get; }
		public override string Namespace => null;
		public override string Name => "<Module>";
		public override DmdTypeAttributes Attributes => DmdTypeAttributes.NotPublic;

		public DmdNullGlobalType(DmdModule module, IList<DmdCustomModifier> customModifiers) : base(1, customModifiers) =>
			Module = module ?? throw new ArgumentNullException(nameof(module));

		public override DmdType WithCustomModifiers(IList<DmdCustomModifier> customModifiers) => AppDomain.Intern(new DmdNullGlobalType(Module, VerifyCustomModifiers(customModifiers)));
		public override DmdType WithoutCustomModifiers() => GetCustomModifiers().Count == 0 ? this : AppDomain.Intern(new DmdNullGlobalType(Module, null));

		protected override int GetDeclaringTypeToken() => 0;
		protected override int GetBaseTypeTokenCore() => 0;
		protected override DmdType[] CreateGenericParameters() => null;

		public override DmdFieldInfo[] ReadDeclaredFields(DmdType reflectedType, IList<DmdType> genericTypeArguments) => null;
		public override DmdMethodBase[] ReadDeclaredMethods(DmdType reflectedType, IList<DmdType> genericTypeArguments) => null;
		public override DmdPropertyInfo[] ReadDeclaredProperties(DmdType reflectedType, IList<DmdType> genericTypeArguments) => null;
		public override DmdEventInfo[] ReadDeclaredEvents(DmdType reflectedType, IList<DmdType> genericTypeArguments) => null;

		protected override DmdType[] ReadDeclaredInterfacesCore(IList<DmdType> genericTypeArguments) => null;
		protected override DmdType[] CreateNestedTypes() => null;
		protected override DmdCustomAttributeData[] CreateCustomAttributes() => null;
	}
}
