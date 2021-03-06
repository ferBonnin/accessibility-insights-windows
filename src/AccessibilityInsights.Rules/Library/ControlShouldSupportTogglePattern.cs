// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using Axe.Windows.Core.Bases;
using Axe.Windows.Core.Enums;
using Axe.Windows.Rules.PropertyConditions;
using Axe.Windows.Rules.Resources;
using static Axe.Windows.Rules.PropertyConditions.ControlType;

namespace Axe.Windows.Rules.Library
{
    [RuleInfo(ID = RuleId.ControlShouldSupportTogglePattern)]
    class ControlShouldSupportTogglePattern : Rule
    {
        public ControlShouldSupportTogglePattern()
        {
            this.Info.Description = Descriptions.ControlShouldSupportTogglePattern;
            this.Info.HowToFix = HowToFix.ControlShouldSupportTogglePattern;
            this.Info.Standard = A11yCriteriaId.AvailableActions;
        }

        public override EvaluationCode Evaluate(IA11yElement e)
        {
            if (e == null) throw new ArgumentException(nameof(e));

            return Patterns.Toggle.Matches(e) ? EvaluationCode.Pass : EvaluationCode.Error;
        }

        protected override Condition CreateCondition()
        {
            // Button is handled separately.
            return AppBar | CheckBox | SemanticZoom;
        }
    } // class
} // namespace
