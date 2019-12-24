using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.UI.Controls;
using OpenQA.Selenium;
using ComplexUIDemo.Ext;

namespace ComplexUIDemo.UI.Pages
{
    public class SwitchPage : BasePage
    {
        public SwitchPage(IWebDriver driver) : base(driver)
        {
        }

         protected List<IWebElement> SwitchContainers => Driver.FindElements(By.CssSelector("#example ul li")).ToList();
        protected List<Slider> Sliders => Driver.FindAll<Slider>(Slider.DefaultLocator);

        /*protected List<IWebElement> SwitchContainers { get
            {
                return Driver.FindElements(By.CssSelector("#example ul li")).ToList(); 
            } }*/

        public void SetAll(bool value)
        {
            //SwitchContainers.ForEach(el => el.Find<Slider>(Slider.DefaultLocator).State = value);
            Sliders.ForEach(slider => slider.State = !value);
        }
    }
}
