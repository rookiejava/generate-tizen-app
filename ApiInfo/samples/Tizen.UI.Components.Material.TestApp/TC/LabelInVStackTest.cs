/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using Tizen.UI;
using Tizen.UI.Components;
using Tizen.UI.Components.Material;
using Tizen.UI.Layouts;

namespace ComponentsTest
{
    internal class LabelInVStackTest : AbsoluteLayout, INavigationTransition, ITestCase
    {
        public LabelInVStackTest()
        {
            BackgroundColor = new Color(0x808080, 1.0f);

            Add(new VStack()
            {
                Name = "Stack",
                BackgroundColor = Color.Red,
                Spacing = 20,
                ItemAlignment = LayoutAlignment.Center,
                Children =
                {
                    new View()
                    {
                        BackgroundColor = Color.Blue,
                    }
                    .Margin(20)
                    .DesiredWidth(100)
                    .DesiredHeight(100),
                    new Label
                    {
                        Name = "TextView",
                        BackgroundColor = Color.Green,
                        Text = "abcdefghijklmnopqrstuvwxyz",
                        IsMultiline = true,
                    }
                    .Margin(20)
                    .TextPadding(20)
                }
            }
            .DesiredWidth(200)
            .Padding(20)
            .MaximumHeight(400));
        }

        public void WillAppear(bool byPopNavigation)
        {
        }

        public void WillDisappear(bool byPopNavigation)
        {
        }

        public void DidAppear(bool byPopNavigation)
        {
        }

        public void DidDisappear(bool byPopNavigation)
        {
            if (byPopNavigation)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
        }

        public void Deactivate()
        {
        }
    }
}
