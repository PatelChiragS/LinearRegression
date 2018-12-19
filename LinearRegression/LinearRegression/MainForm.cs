/*
 * ${res:XML.StandardHeader.CreatedByChiragPatel}
 * Creator: Chirag
 * Date: 6/22/2016
 * Time: 4:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;

namespace LinearRegression
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    this.AutoSize = true;
        //    this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        //}

        public MainForm()
		{			
			InitializeComponent();
		}

        ArrayList resultP0 = new ArrayList();
        ArrayList resultP1 = new ArrayList();
        double slope11;
        double[] res;
        double[] arrayRes;
        double[] arrayPred;
        double intercept11;
        double[] pred;
        double[] yv;
		
				
		void BtnresetClick(object sender, EventArgs e)
		{
            yvaluestxtbox.Text = "";
            xvaluestxtbox.Text = "";
            xxvaluestxtbox.Text = "";
            yyvaluestxtbox.Text = "";
            xyvaluestxtbox.Text = "";
            sumy.Text = "";
            sumx.Text = "";
            sumxx.Text = "";
            sumyy.Text = "";
            sumxy.Text = "";
            meanx.Text = "";
            meany.Text = "";
            slope1.Text = "";
            intercept.Text = "";
            rsquared1.Text = "";
            predicty.Text = "";
            residual.Text = "";
            resultP0.Clear();
            resultP1.Clear();
            xintervalchart1.Text = "";
            xintervalchart2.Text = "";
            xintervalchart3.Text = "";

            avalue.Text = "";
            bvalue.Text = "";
            xvalue.Text = "";
            yvalue.Text = "";

            yvalname.Text = "";
            xvalname.Text = "";
            alabel.Text = "";
            blabel.Text = "";
            xlabel.Text = "";
            ylabel.Text = "";

            df1.Text = "";
            df2.Text = "";
            df3.Text = "";
            ss1.Text = "";
            ss2.Text = "";
            ss3.Text = "";
            ms1.Text = "";
            ms2.Text = "";
            f1.Text = "";
            //p.Text = "";

            coef1.Text = "";
            coef2.Text = "";
            secoef1.Text = "";
            secoef2.Text = "";
            t1.Text = "";
            t2.Text = "";
            p1.Text = "";
            p2.Text = "";
            ssrvalues.Text = "";
            ssrvaluessum.Text = "";
            xlabelvalue.Text= "";

            rsquared1per.Text = "";
            rsquared2.Text = "";
            rsquared2per.Text = "";

            esquare.Text = "";
            esquaresum.Text = "";

            ysvariance.Text = "";
            xsvariance.Text = "";
            stdvX.Text = "";
            stdvY.Text = "";
            avallabel.Text = "";
            bvallabel.Text = "";
            xvallabel.Text = "";
            yvallabel.Text = "";

            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();

		}
		
		void BtncalculateClick(object sender, EventArgs e)
		{
			
			//MessageBox.Show("Hang in there..I am coming");
            double rsquared;
            double yintercept;
            double slope;
            double median;

            xxvaluestxtbox.Text = "";
            yyvaluestxtbox.Text = "";
            xyvaluestxtbox.Text = "";
            sumy.Text = "";
            sumx.Text = "";
            sumxx.Text = "";
            sumyy.Text = "";
            sumxy.Text = "";
            meanx.Text = "";
            meany.Text = "";
            slope1.Text = "";
            intercept.Text = "";
            rsquared1.Text = "";
            predicty.Text = "";
            residual.Text = "";
            resultP0.Clear();
            resultP1.Clear();

            SingleLinearRegression(out rsquared, out yintercept, out median, out slope);
            slope11 = slope;
            intercept11 = yintercept;
            yv = new double[] { slope11, intercept11 };

            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            Chart1Code(4,slope11,intercept11);  // 4 is axis interval value
            Chart2Code(4);  // 4 is axis interval value
            Chart3Code(4);  // 4 is axis interval value

        }

        double[] xVals;
        double[] yVals;

        private void SingleLinearRegression(out double rsquared, out double yintercept, out double median, out double slope)
        {

            rsquared = 0;
            yintercept = 0;
            median = 0;
            slope = 0;

            try 
            {
                List<string> yValTemp = new List<string>();
                yValTemp.AddRange(yvaluestxtbox.Lines);
                string ty = String.Join(",", yValTemp);
                yVals = Array.ConvertAll(ty.Split(','), Double.Parse);

                List<string> xValTemp = new List<string>();
                xValTemp.AddRange(xvaluestxtbox.Lines);
                string tx = String.Join(",", xValTemp);
                xVals = Array.ConvertAll(tx.Split(','), Double.Parse);

                int inclusiveStart = 0;
                int exclusiveEnd = xVals.Length;

                double sumOfX = 0;
                double sumOfY = 0;
                double sumOfXSq = 0;
                double sumOfYSq = 0;
                double ssX = 0;
                double ssY = 0;
                double sumCodeviates = 0;
                double sCo = 0;
                double x = 0;
                double y = 0;
                double x1 = 0;
                double y1 = 0;
                double count = exclusiveEnd - inclusiveStart;

                for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
                {
                    x = xVals[ctr];
                    y = yVals[ctr];
                    sumCodeviates += x * y;
                    xyvaluestxtbox.Text += Math.Round((x * y), 3) + "," + "\r\n";
                    sumOfX += x;
                    sumOfY += y;
                    sumOfXSq += x * x;
                    xxvaluestxtbox.Text += Math.Round((x * x), 3) + "," + "\r\n";
                    sumOfYSq += y * y;
                    yyvaluestxtbox.Text += Math.Round((y * y), 3) + "," + "\r\n";

                    //xxvaluestxtbox.Text = xxvaluestxtbox.Text.Substring(0, xxvaluestxtbox.Text.Length - 1);
                    //yyvaluestxtbox.Text = yyvaluestxtbox.Text.Substring(0, yyvaluestxtbox.Text.Length - 1);
                    //xyvaluestxtbox.Text = xyvaluestxtbox.Text.Substring(0, xyvaluestxtbox.Text.Length - 1);

                    sumy.Text = Math.Round(sumOfY, 3).ToString();
                    sumx.Text = Math.Round(sumOfX, 3).ToString();
                    sumyy.Text = Math.Round(sumOfYSq, 3).ToString();
                    sumxx.Text = Math.Round(sumOfXSq, 3).ToString();
                    sumxy.Text = Math.Round(sumCodeviates, 3).ToString();

                    ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
                    ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
                    double RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
                    double RDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
                    sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

                    double meanX = sumOfX / count;
                    double meanY = sumOfY / count;
                    meanx.Text = Math.Round(meanX, 3).ToString();
                    meany.Text = Math.Round(meanY, 3).ToString();

                    double dblR = RNumerator / Math.Sqrt(RDenom);
                    rsquared = dblR * dblR;

                    yintercept = meanY - ((sCo / ssX) * meanX);
                    slope = sCo / ssX;
                    median = (yintercept + slope) / 2;

                    slope1.Text = Math.Round(slope, 3).ToString();
                    intercept.Text = Math.Round(yintercept, 3).ToString();
                    rsquared1.Text = Math.Round(rsquared, 3).ToString();
                    rsquared1per.Text = (Convert.ToDouble(rsquared1.Text) * 100).ToString();

                    double n = yVals.Length * xVals.Length;  //Total No. of Datapoints
                    double k = xVals.Length;  // No. of independent variablesd                  

                    double step1 = 1 - Convert.ToDouble(rsquared1.Text);
                    double step2 = n - 1;
                    double step3 = n - k - 1;

                    rsquared2.Text = Math.Round((1 - ((step1 * step2) / step3)), 3).ToString(); // r-squared(adj.) formula
                    rsquared2per.Text = (Convert.ToDouble(rsquared2.Text) * 100).ToString();

                    df1.Text = "1";
                    df2.Text = (xVals.Length - 2).ToString();
                    df3.Text = (xVals.Length - 1).ToString();

                }

                double esqrd = 0;
                double ssrval = 0;

                double varianceXsT = 0;
                double varianceYsT = 0;
                double varianceXs = 0;                
                double varianceYs = 0;
                
                for (int ctr1 = inclusiveStart; ctr1 < exclusiveEnd; ctr1++)
                {
                    x1 = xVals[ctr1];
                    y1 = yVals[ctr1];
                    predicty.Text += Math.Round((yintercept + (slope * (x1))), 3) + "," + "\r\n";
                    residual.Text += Math.Round((y1 - (yintercept + (slope * (x1)))), 3) + "," + "\r\n";
                    esquare.Text += Math.Round(Math.Pow((y1 - (yintercept + (slope * (x1)))), 2), 3) + "," + "\r\n";   
                    ssrvalues.Text += Math.Round(Math.Pow((y1 - (Convert.ToDouble(meany.Text))), 2), 3) + "," + "\r\n";
                    esqrd += Math.Pow((y1 - (yintercept + (slope * (x1)))), 2);
                    ssrval += Math.Round(Math.Pow((y1 - (Convert.ToDouble(meany.Text))), 2), 3);
                    res = new double[] { Math.Round((y1 - (yintercept + (slope * (x1)))), 3) };
                    resultP0.Add(res[0]);
                    pred = new double[] { Math.Round((yintercept + (slope * (x1))), 3) };
                    resultP1.Add(pred[0]);

                    varianceXsT += Math.Pow((xVals[ctr1] - Math.Round(Convert.ToDouble(meanx.Text), 3)), 2);
                    varianceYsT += Math.Pow((yVals[ctr1] - Math.Round(Convert.ToDouble(meany.Text), 3)), 2);

                }

                varianceXs = varianceXsT / (xVals.Length - 1);               
                varianceYs = varianceYsT / (xVals.Length - 1);
                ysvariance.Text = Math.Round(varianceYs,3).ToString();
                xsvariance.Text = Math.Round(varianceXs,3).ToString();
                double StDvX = Math.Sqrt(Convert.ToDouble(varianceXs));
                double StDvY = Math.Sqrt(Convert.ToDouble(varianceYs));

                stdvX.Text = Math.Round(StDvX, 3).ToString();
                stdvY.Text = Math.Round(StDvY, 3).ToString();
                
                esquaresum.Text = Math.Round(esqrd, 3).ToString();
                ss2.Text = Math.Round(esqrd, 3).ToString();
                ssrvaluessum.Text = Math.Round(ssrval, 3).ToString();
                ss3.Text = Math.Round(ssrval, 3).ToString();
                ss1.Text = (Convert.ToDouble(ss3.Text) - Convert.ToDouble(ss2.Text)).ToString();
                ms1.Text = (Convert.ToDouble(ss1.Text) / Convert.ToDouble(df1.Text)).ToString();
                ms2.Text = (Convert.ToDouble(ss2.Text) / Convert.ToDouble(df2.Text)).ToString();
                f1.Text = (Convert.ToDouble(ms1.Text) / Convert.ToDouble(ms2.Text)).ToString();
                arrayRes = resultP0.ToArray(typeof(double)) as double[];
                arrayPred = resultP1.ToArray(typeof(double)) as double[];

                avalue.Text = intercept.Text;
                bvalue.Text = slope1.Text;
                ylabel.Text = "Predict " + yvalname.Text;
                xlabel.Text = xvalname.Text;
                alabel.Text = "Intercept";
                blabel.Text = "Slope";
                xlabelvalue.Text = xvalname.Text;
                coef1.Text = intercept.Text;
                coef2.Text = slope1.Text;

                svalue.Text = Math.Sqrt(Convert.ToDouble(ms2.Text)).ToString();
                yvallabel.Text = yvalname.Text;
                xvallabel.Text = xvalname.Text;
                avallabel.Text = intercept.Text;
                bvallabel.Text = slope1.Text;
                //The P-value is P(F(2,12) ≥ 93.44) < 0.001
                //p.Text = ;
                //f1
                pequation.Text = "P-Value is: P(F(" + df1.Text + "," + df2.Text + ") >= " + Math.Round(Convert.ToDouble(f1.Text),2) + ") < 0.001";
                secoef1.Text = Math.Round((Convert.ToDouble(coef1.Text) - Convert.ToDouble(ms2.Text)),3).ToString();
                t1.Text = Math.Round((Convert.ToDouble(coef1.Text) / Convert.ToDouble(secoef1.Text)),3).ToString();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Chart1Code(double interval, double slope, double intercept)
        {           
            double[] x = xVals;
            double[] y = yVals;

            try
            { 
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].Axes[0].Title = xvalname.Text; //"x";
                chart1.ChartAreas[0].Axes[1].Title = yvalname.Text; //"y";
                chart1.BackColor = System.Drawing.Color.LightGray;
                chart1.ChartAreas[0].AxisY.Interval = 10;
                chart1.ChartAreas[0].AxisY.Minimum = yVals.Min() - 1;
            
                if (string.IsNullOrWhiteSpace(xintervalchart1.Text))
                {
                    chart1.ChartAreas[0].AxisX.Interval = 4;
                }
                else chart1.ChartAreas[0].AxisX.Interval = interval;

                chart1.ChartAreas[0].AxisX.Minimum = xVals.Min() - 1;
                //chart1.ChartAreas[0].AxisX.Maximum = xVals.Max() + interval;

                //chart1.ChartAreas[0].AxisX.Interval = 4;
                //chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;           
                Series s1 = new Series("Slope");
                chart1.Series.Add(s1);
                //s1.YValuesPerPoint = 2;
                //chart1.Series[0].ChartType = SeriesChartType.FastLine;
                chart1.Series[0].ChartType = SeriesChartType.Point;
                chart1.Palette = ChartColorPalette.None;
                chart1.PaletteCustomColors = new Color[] { Color.DarkRed };
                chart1.Series[0].MarkerStyle = MarkerStyle.Circle;

                for (int i = 0; i < y.Length; i++)
                {
                    //chart1.Series[0].Points.AddXY(Convert.ToString(x[i]), Convert.ToString(y[i]));
                    chart1.Series[0].Points.AddXY(x[i], y[i]);
                }

                double x1_t = xVals[0];
                double y1_t = (slope + intercept);
                double x2_t = xVals[xVals.Length - 1];
                double y2_t = (slope * xVals.Length) + intercept;

                chart1.Series.Add("Line");
                chart1.Series["Line"].Points.Add(new DataPoint(x1_t, y1_t));
                chart1.Series["Line"].Points.Add(new DataPoint(x2_t, y2_t));
                chart1.Series["Line"].Color = Color.Green;
                //chart1.PaletteCustomColors = new Color[] { Color.DarkBlue };
                chart1.Series["Line"].ChartType = SeriesChartType.Line;                

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnmodifyintervalchart1_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series.Clear();
                //Chart1Code(Convert.ToDouble(xintervalchart1.Text),null,null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }


        private void Chart2Code(double interval)
        {
            double[] x = arrayPred;
            double[] y = arrayRes;

            //foreach (double s in x)

            //    MessageBox.Show(s.ToString());
           try
            {   
                chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart2.ChartAreas[0].Axes[0].Title = "Fitted Value";
                chart2.ChartAreas[0].Axes[1].Title = "Residual, e";
                chart2.BackColor = System.Drawing.Color.LightGray;

                if (string.IsNullOrWhiteSpace(xintervalchart2.Text))
                {
                    chart2.ChartAreas[0].AxisX.Interval = 4;
                }
                else chart2.ChartAreas[0].AxisX.Interval = interval;

                //chart2.ChartAreas[0].AxisX.Interval = 4;
                Series s1 = new Series("Slope");
                //chart2.ChartAreas[0].AxisX.Interval = 1;
                //chart2.ChartAreas[0].AxisY.Interval = 1;
                chart2.Series.Add(s1);
                chart2.Series[0].ChartType = SeriesChartType.Point;
                chart2.Palette = ChartColorPalette.None;
                chart2.PaletteCustomColors = new Color[] { Color.DarkBlue };
                chart2.Series[0].MarkerStyle = MarkerStyle.Circle;

                for (int i = 0; i < y.Length; i++)
                {
                    //chart2.Series[0].Points.AddXY(Convert.ToString(x[i]), Convert.ToString(y[i]));
                    chart2.Series[0].Points.AddXY(x[i], y[i]);
                }
                chart2.ChartAreas[0].AxisX.Crossing = 0;
                chart2.ChartAreas[0].AxisY.Crossing = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnmodifyintervalchart2_Click(object sender, EventArgs e)
        {
            try
            { 
                chart2.Series.Clear();
                Chart2Code(Convert.ToDouble(xintervalchart2.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Chart3Code(double interval)
        {
            double[] x = xVals;
            double[] y = arrayRes;           
            double sum_y = 0;
            double mean = 0;

            try
            { 
                foreach (double n in y)
                    sum_y += n;
                mean = sum_y / y.Length;
                chart3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart3.ChartAreas[0].Axes[0].Title = "Independent Variable, X";
                chart3.ChartAreas[0].Axes[1].Title = "Residual, e";
                chart3.BackColor = System.Drawing.Color.LightGray;

                if (string.IsNullOrWhiteSpace(xintervalchart3.Text))
                {
                    chart3.ChartAreas[0].AxisX.Interval = 4;
                }
                else chart3.ChartAreas[0].AxisX.Interval = interval;

                //chart3.ChartAreas[0].AxisX.Interval = 4;
                Series s1 = new Series("Slope");
                chart3.Series.Add(s1);
                chart3.Series[0].ChartType = SeriesChartType.Point;
                chart3.Palette = ChartColorPalette.None;
                chart3.PaletteCustomColors = new Color[] { Color.DarkBlue };
                chart3.Series[0].MarkerStyle = MarkerStyle.Circle;
                for (int i = 0; i < y.Length; i++)
                {
                    //chart3.Series[0].Points.AddXY(Convert.ToString(x[i]), Convert.ToString(y[i]));
                    chart3.Series[0].Points.AddXY(x[i], y[i]);
                }
                //chart3.ChartAreas[0].AxisX.LabelStyle.Interval = 0.5;  // shows all the labels on x-axis   
                chart3.ChartAreas[0].AxisX.Crossing = 0;
                chart3.ChartAreas[0].AxisY.Crossing = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnmodifyintervalchart3_Click(object sender, EventArgs e)
        {
            try
            {
                chart3.Series.Clear();
                Chart3Code(Convert.ToDouble(xintervalchart3.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btncalculateM_Click(object sender, EventArgs e)
        {

            //double F1; double F2; double F3;
            yymvaluestxtbox.Text = "";
            x1yvaluestxtbox.Text = "";
            x2yvaluestxtbox.Text = "";
            x3yvaluestxtbox.Text = "";
            x1x2valuestxtbox.Text = "";
            x2x3valuestxtbox.Text = "";
            x1x3valuestxtbox.Text = "";
            x1x1valuestxtbox.Text = "";
            x2x2valuestxtbox.Text = "";
            x3x3valuestxtbox.Text = "";
            sumym.Text = "";
            sumx1m.Text = "";
            sumx2m.Text = "";
            sumx3m.Text = "";
            sumx1x1.Text = "";
            sumx2x2.Text = "";
            sumx3x3.Text = "";
            sumx1x2.Text = "";
            sumx2x3.Text = "";
            sumx1x3.Text = "";
            sumyym.Text = "";
            sumx1y.Text = "";
            sumx2y.Text = "";
            sumx3y.Text = "";
            meanx1m.Text = "";
            meanx2m.Text = "";
            meanx3m.Text = "";
            meanym.Text = "";
            yvariance.Text = "";
            x1variance.Text = "";
            x2variance.Text = "";
            x3variance.Text = "";
            ystdv.Text = "";
            x1stdv.Text = "";
            x2stdv.Text = "";
            x3stdv.Text = "";
            estefx1.Text = "";
            estefx2.Text = "";
            estefx3.Text = "";
            treat1.Text = "";
            treat2.Text = "";
            treat3.Text = "";
            treat4.Text = "";
            treat5.Text = "";
            error1.Text = "";
            error2.Text = "";
            error3.Text = "";
            total1.Text = "";
            total2.Text = "";

            //ytextbox.Text = "";
            //x1textbox.Text = "";
            //x2textbox.Text = "";
            //x3textbox.Text = "";

            resultP0.Clear();
            resultP1.Clear();
            
            //MultipleLinearRegression(out F1, out F2, out F3);
            MultipleLinearRegression();
            
            M2Chart1Code();  // 4 is axis interval value
            //Mchart1.Series[0].LegendText = "";
            //Mchart1.Series[1].LegendText = "";

            //MessageBox.Show(F1.ToString());

        }

        private void MultipleLinearRegression()
        {
            try
            { 
                double F1; double F2; double F3;
                int num = Convert.ToInt16(txtnum.Text);
                if(num == 2)
                {
                    MultipleLinearRegression_2(out F1, out F2);
                }
                if (num == 3)
                {
                    MultipleLinearRegression_3(out F1, out F2, out F3);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        double[] y_val;
        double[] F1_val;
        double[] F2_val;
        double[] F3_val;

        private void MultipleLinearRegression_2(out double F1, out double F2)
        {
                        
            //double[] y_val;
            //double[] F1_val;
            //double[] F2_val;
            
            F1 = 0;
            F2 = 0;            

            try
            {
                
                List<string> yValTempM = new List<string>();
                yValTempM.AddRange(ymvaluestxtbox.Lines);
                string ty = String.Join(",", yValTempM);
                y_val = Array.ConvertAll(ty.Split(','), Double.Parse);

                List<string> x1ValTemp = new List<string>();
                x1ValTemp.AddRange(x1valuestxtbox.Lines);
                string tx1 = String.Join(",", x1ValTemp);
                F1_val = Array.ConvertAll(tx1.Split(','), Double.Parse);
                
                List<string> x2ValTemp = new List<string>();
                x2ValTemp.AddRange(x2valuestxtbox.Lines);
                string tx2 = String.Join(",", x2ValTemp);
                F2_val = Array.ConvertAll(tx2.Split(','), Double.Parse);
                

                // put the function in loop with Xvalues and Yvalues.          
                
                //double[][] xVals = new double[][]{
                //                        new double[]{0.0000,-1.0000,4.9187,0.0000,-1.0000,-1.6103,0.0000,-1.0000,3.9932 }
                //                        };
                //, { 3.9187, -2.6103, 2.9932 }
                //double[, ,] xVals3D = new double[,,] { { { 0.0000, -1.0000, 4.9187 }, { 0.0000, -1.0000, -1.6103 }, { 0.0000, -1.0000, 3.9932 } } };
                
                //double[] x_val1 = { 0.0000, -1.0000, 4.9187 };  // F1 values from scenario_key.csv
                //double[] x_val2 = { 0.0000, -1.0000, -1.6103 }; // F2 values from scenario_key.csv
                //double[] x_val3 = { 0.0000, -1.0000, 3.9932 };  // F3 values from scenario_key.csv
                //double[] y_vals = { 0, -0.2911006, 2.7642458 }; m[13,1] from R
                
                //double[] y_vals = { 0, -0.2916458, 2.7319057 };  // arrayP0 for 0_month   and m[13,2] from R
                
                double[] x_val1 = F1_val;
                double[] x_val2 = F2_val;
                
                double[] y_vals = y_val;

                int num = Convert.ToInt16(txtnum.Text);

                double sum_x1 = 0;
                double sum_x2 = 0;
                
                double sum_y = 0;

                foreach (double n in x_val1)
                    sum_x1 += n;

                foreach (double n in x_val2)
                    sum_x2 += n;
                
                foreach (double n in y_vals)
                    sum_y += n;
                
                double meanX1 = sum_x1 / x_val1.Length;
                double meanX2 = sum_x2 / x_val2.Length;
                
                double meanY1 = sum_y / y_vals.Length;

                grandmean.Text = Math.Round(((sum_x1 + sum_x2) / (x_val1.Length + x_val2.Length)), 4).ToString();
                double overallmean = Math.Round(((sum_x1 + sum_x2) / (x_val1.Length + x_val2.Length)), 4);

                estefx1.Text = Math.Round((meanX1 - overallmean), 4).ToString();
                estefx2.Text = Math.Round((meanX2 - overallmean), 4).ToString();
                
                treat1.Text = (num - 1).ToString(); // 3 -- x1 , x2, x3

                error1.Text = ((x_val1.Length + x_val2.Length) - num).ToString(); // 3 -- x1 , x2, x3

                //total1.Text = ((x_val1.Length + x_val2.Length + x_val3.Length) - 1).ToString();

                total1.Text = ((num - 1) + ((x_val1.Length + x_val2.Length) - num)).ToString();
                double treat2val = (Math.Pow((Math.Round((meanX1 - overallmean), 4)), 2) * x_val1.Length) +
                                    (Math.Pow((Math.Round((meanX2 - overallmean), 4)), 2) * x_val2.Length);

                treat2.Text = (Math.Round(treat2val, 4)).ToString();
                treat3.Text = (Math.Round((treat2val / (num - 1)), 4)).ToString();

                sumym.Text = Math.Round(sum_y, 3).ToString();
                sumx1m.Text = Math.Round(sum_x1, 3).ToString();
                sumx2m.Text = Math.Round(sum_x2, 3).ToString();
                
                meanym.Text = Math.Round(meanY1, 3).ToString();
                meanx1m.Text = Math.Round(meanX1, 3).ToString();
                meanx2m.Text = Math.Round(meanX2, 3).ToString();                
                
                // Correlation factor values

                double cor_x1y = Correlation(x_val1, y_vals);
                double cor_x2y = Correlation(x_val2, y_vals);
                double cor_y = Correlation(y_vals, y_vals);

                double cor_x1x1 = Correlation(x_val1, x_val1);
                double cor_x2x2 = Correlation(x_val2, x_val2);                                            
                double cor_x1x2 = Correlation(x_val1, x_val2);
                
                double varianceX1T = 0;
                double varianceX2T = 0;                
                double varianceYT = 0;
                double varianceX1 = 0;
                double varianceX2 = 0;                
                double varianceY = 0;

                //double error2val1 = 0;

                for (int iv = 0; iv < x_val1.Length; iv++)
                {
                    varianceX1T += Math.Pow((x_val1[iv] - meanX1), 2);
                    varianceX2T += Math.Pow((x_val2[iv] - meanX2), 2);                    
                    varianceYT += Math.Pow((y_vals[iv] - meanY1), 2);
                }

                varianceX1 = varianceX1T / (x_val1.Length - 1);
                varianceX2 = varianceX2T / (x_val1.Length - 1);                
                varianceY = varianceYT / (x_val1.Length - 1);

                double StandardDeviationX1 = Math.Sqrt(Convert.ToDouble(varianceX1));
                double StandardDeviationX2 = Math.Sqrt(Convert.ToDouble(varianceX2));                
                double StandardDeviationY = Math.Sqrt(Convert.ToDouble(varianceY));

                yvariance.Text = Math.Round(varianceY, 3).ToString();
                x1variance.Text = Math.Round(varianceX1, 3).ToString();
                x2variance.Text = Math.Round(varianceX2, 3).ToString();
                
                ystdv.Text = Math.Round(StandardDeviationY, 3).ToString();
                x1stdv.Text = Math.Round(StandardDeviationX1, 3).ToString();
                x2stdv.Text = Math.Round(StandardDeviationX2, 3).ToString();                

                //ANOVA Summary (error - SS)
                error2.Text = Math.Round((varianceX1T + varianceX2T), 4).ToString();
                // error3 = treat3 / error3
                error3.Text = Math.Round(((varianceX1T + varianceX2T) / ((x_val1.Length + x_val2.Length) - num)), 4).ToString();
                // total2 = treat2 + error2
                total2.Text = (Math.Round(treat2val, 4) + Math.Round((varianceX1T + varianceX2T), 4)).ToString();
                // treat4 = treat3 / error3
                treat4.Text = Math.Round(((treat2val / (num - 1)) / ((varianceX1T + varianceX2T) / ((x_val1.Length + x_val2.Length) - num))), 4).ToString();

                rsquared.Text = Math.Round((1 - (Convert.ToDouble(treat2.Text) / Convert.ToDouble(total2.Text))), 4).ToString();
                rsquaredadj.Text = Math.Round((1 - (((Convert.ToDouble(total1.Text) / Convert.ToDouble(treat1.Text)) * (Convert.ToDouble(treat2.Text) / Convert.ToDouble(total2.Text))))), 4).ToString();

                int inclusiveStart = 0;
                int exclusiveEnd = x_val1.Length;
                double x1; //= 0;
                double x2; //= 0;
                
                double y = 0;
                double sumx1_y = 0;
                double sumx2_y = 0;                
                double sumy_y = 0;

                double sumx1_x2 = 0;
                double sumx1_x1 = 0;
                double sumx2_x2 = 0;
                
                
                for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
                {
                    x1 = x_val1[ctr];
                    x2 = x_val2[ctr];                    
                    y = y_vals[ctr];

                    sumx1_y += Math.Round((x1 * y), 3);
                    sumx2_y += Math.Round((x2 * y), 3);
                    
                    sumy_y += Math.Round((y * y), 3);
                    sumx1_x1 += Math.Round((x1 * x1), 3);
                    sumx2_x2 += Math.Round((x2 * x2), 3);                    
                    sumx1_x2 += Math.Round((x1 * x2), 3);
                    
                    x1yvaluestxtbox.Text += Math.Round((x1 * y), 3) + "," + "\r\n";
                    x2yvaluestxtbox.Text += Math.Round((x2 * y), 3) + "," + "\r\n";                    
                    x1x1valuestxtbox.Text += Math.Round((x1 * x1), 3) + "," + "\r\n";
                    x2x2valuestxtbox.Text += Math.Round((x2 * x2), 3) + "," + "\r\n";                    
                    x1x2valuestxtbox.Text += Math.Round((x1 * x2), 3) + "," + "\r\n";
                    yymvaluestxtbox.Text += Math.Round((y * y), 3) + "," + "\r\n";

                }
                
                sumx1y.Text += sumx1_y.ToString();
                sumx2y.Text += sumx2_y.ToString();                
                sumyym.Text += sumy_y.ToString();
                sumx1x1.Text += sumx1_x1.ToString();
                sumx2x2.Text += sumx2_x2.ToString();               
                sumx1x2.Text += sumx1_x2.ToString();                

                //double r1 = ((0.997404903 * 0.997404903) + (-0.7324762 * -0.7324762) - (2 * (0.997404903 * -0.7324762 * -0.681560844649687)));
                //double r2 = 1 - (-0.681560844649687 * -0.681560844649687);
                //double r3 = r1 / r2;
                //double r4 = Math.Sqrt(r3);
                //MessageBox.Show(r4.ToString());

                //Y’ = a + b1*X1 + b2*X2 + b3*X3
                //Y’ = predicted value of Y
                //a = "Y Intercept"
                // need b1, b2 , b3 values as F1, F2, F3 values
                
                double b1 = ((cor_x1y - (cor_x2y * cor_x1x2)) / (1 - (cor_x1x2 * cor_x1x2))) * (StandardDeviationY / StandardDeviationX1);
                double b2 = ((cor_x2y - (cor_x1y * cor_x1x2)) / (1 - (cor_x1x2 * cor_x1x2))) * (StandardDeviationY / StandardDeviationX2);                

                //rsquared = r4;

                F1 = b1;
                F2 = b2;
                
                x1coeff.Text = Math.Round(b1, 3).ToString();
                x2coeff.Text = Math.Round(b2, 3).ToString();
                
                interceptm.Text = (Math.Round(b1, 3) * sum_x1 + Math.Round(b2, 3) * sum_x2 - sum_y).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MultipleLinearRegression_3(out double F1, out double F2, out double F3)
        {

            //double[] y_val;
            //double[] F1_val;
            //double[] F2_val;
            //double[] F3_val;
            F1 = 0;
            F2 = 0;
            F3 = 0;

            try
            {

                List<string> yValTempM = new List<string>();
                yValTempM.AddRange(ymvaluestxtbox.Lines);
                string ty = String.Join(",", yValTempM);
                y_val = Array.ConvertAll(ty.Split(','), Double.Parse);
                List<string> x1ValTemp = new List<string>();
                x1ValTemp.AddRange(x1valuestxtbox.Lines);
                string tx1 = String.Join(",", x1ValTemp);
                F1_val = Array.ConvertAll(tx1.Split(','), Double.Parse);

                List<string> x2ValTemp = new List<string>();
                x2ValTemp.AddRange(x2valuestxtbox.Lines);
                string tx2 = String.Join(",", x2ValTemp);
                F2_val = Array.ConvertAll(tx2.Split(','), Double.Parse);

                List<string> x3ValTemp = new List<string>();
                x3ValTemp.AddRange(x3valuestxtbox.Lines);
                string tx3 = String.Join(",", x3ValTemp);
                F3_val = Array.ConvertAll(tx3.Split(','), Double.Parse);


                // put the function in loop with Xvalues and Yvalues.

                //double[][] xVals = new double[][]{
                //                        new double[]{0.0000,-1.0000,4.9187,0.0000,-1.0000,-1.6103,0.0000,-1.0000,3.9932 }
                //                        };
                //, { 3.9187, -2.6103, 2.9932 }
                //double[, ,] xVals3D = new double[,,] { { { 0.0000, -1.0000, 4.9187 }, { 0.0000, -1.0000, -1.6103 }, { 0.0000, -1.0000, 3.9932 } } };
                //double[] x_val1 = { 0.0000, -1.0000, 4.9187 };  // F1 values from scenario_key.csv
                //double[] x_val2 = { 0.0000, -1.0000, -1.6103 }; // F2 values from scenario_key.csv
                //double[] x_val3 = { 0.0000, -1.0000, 3.9932 };  // F3 values from scenario_key.csv
                //double[] y_vals = { 0, -0.2911006, 2.7642458 }; m[13,1] from R
                //double[] y_vals = { 0, -0.2916458, 2.7319057 };  // arrayP0 for 0_month   and m[13,2] from R

                double[] x_val1 = F1_val;
                double[] x_val2 = F2_val;
                double[] x_val3 = F3_val;
                double[] y_vals = y_val;

                double sum_x1 = 0;
                double sum_x2 = 0;
                double sum_x3 = 0;
                double sum_y = 0;

                foreach (double n in x_val1)
                    sum_x1 += n;

                foreach (double n in x_val2)
                    sum_x2 += n;

                foreach (double n in x_val3)
                    sum_x3 += n;

                foreach (double n in y_vals)
                    sum_y += n;

                double meanX1 = sum_x1 / x_val1.Length;
                double meanX2 = sum_x2 / x_val2.Length;
                double meanX3 = sum_x3 / x_val3.Length;
                double meanY1 = sum_y / y_vals.Length;

                grandmean.Text = Math.Round(((sum_x1 + sum_x2 + sum_x3) / (x_val1.Length + x_val2.Length + x_val3.Length)), 4).ToString();
                double overallmean = Math.Round(((sum_x1 + sum_x2 + sum_x3) / (x_val1.Length + x_val2.Length + x_val3.Length)), 4);

                estefx1.Text = Math.Round((meanX1 - overallmean), 4).ToString();
                estefx2.Text = Math.Round((meanX2 - overallmean), 4).ToString();
                estefx3.Text = Math.Round((meanX3 - overallmean), 4).ToString();
                treat1.Text = (3 - 1).ToString(); // 3 -- x1 , x2, x3

                error1.Text = ((x_val1.Length + x_val2.Length + x_val3.Length) - 3).ToString(); // 3 -- x1 , x2, x3

                //total1.Text = ((x_val1.Length + x_val2.Length + x_val3.Length) - 1).ToString();

                total1.Text = ((3 - 1) + ((x_val1.Length + x_val2.Length + x_val3.Length) - 3)).ToString();
                double treat2val = (Math.Pow((Math.Round((meanX1 - overallmean), 4)), 2) * x_val1.Length) +
                                    (Math.Pow((Math.Round((meanX2 - overallmean), 4)), 2) * x_val2.Length) +
                                    (Math.Pow((Math.Round((meanX3 - overallmean), 4)), 2) * x_val3.Length);

                treat2.Text = (Math.Round(treat2val, 4)).ToString();
                treat3.Text = (Math.Round((treat2val / (3 - 1)), 4)).ToString();

                sumym.Text = Math.Round(sum_y, 3).ToString();
                sumx1m.Text = Math.Round(sum_x1, 3).ToString();
                sumx2m.Text = Math.Round(sum_x2, 3).ToString();
                sumx3m.Text = Math.Round(sum_x3, 3).ToString();
                meanym.Text = Math.Round(meanY1, 3).ToString();
                meanx1m.Text = Math.Round(meanX1, 3).ToString();
                meanx2m.Text = Math.Round(meanX2, 3).ToString();
                meanx3m.Text = Math.Round(meanX3, 3).ToString();

                // Correlation factor values

                double cor_x1y = Correlation(x_val1, y_vals);
                double cor_x2y = Correlation(x_val2, y_vals);
                double cor_x3y = Correlation(x_val3, y_vals);

                double cor_x1x1 = Correlation(x_val1, x_val1);
                double cor_x2x2 = Correlation(x_val2, x_val2);
                double cor_x3x3 = Correlation(x_val3, x_val3);
                double cor_y = Correlation(y_vals, y_vals);

                double cor_x1x2 = Correlation(x_val1, x_val2);
                double cor_x2x3 = Correlation(x_val2, x_val3);
                double cor_x1x3 = Correlation(x_val1, x_val3);
                double cor_x3x1 = Correlation(x_val3, x_val1);

                double varianceX1T = 0;
                double varianceX2T = 0;
                double varianceX3T = 0;
                double varianceYT = 0;
                double varianceX1 = 0;
                double varianceX2 = 0;
                double varianceX3 = 0;
                double varianceY = 0;

                //double error2val1 = 0;

                for (int iv = 0; iv < x_val1.Length; iv++)
                {
                    varianceX1T += Math.Pow((x_val1[iv] - meanX1), 2);
                    varianceX2T += Math.Pow((x_val2[iv] - meanX2), 2);
                    varianceX3T += Math.Pow((x_val3[iv] - meanX3), 2);
                    varianceYT += Math.Pow((y_vals[iv] - meanY1), 2);
                }

                varianceX1 = varianceX1T / (x_val1.Length - 1);
                varianceX2 = varianceX2T / (x_val1.Length - 1);
                varianceX3 = varianceX3T / (x_val1.Length - 1);
                varianceY = varianceYT / (x_val1.Length - 1);

                double StandardDeviationX1 = Math.Sqrt(Convert.ToDouble(varianceX1));
                double StandardDeviationX2 = Math.Sqrt(Convert.ToDouble(varianceX2));
                double StandardDeviationX3 = Math.Sqrt(Convert.ToDouble(varianceX3));
                double StandardDeviationY = Math.Sqrt(Convert.ToDouble(varianceY));

                yvariance.Text = Math.Round(varianceY, 3).ToString();
                x1variance.Text = Math.Round(varianceX1, 3).ToString();
                x2variance.Text = Math.Round(varianceX2, 3).ToString();
                x3variance.Text = Math.Round(varianceX3, 3).ToString();
                ystdv.Text = Math.Round(StandardDeviationY, 3).ToString();
                x1stdv.Text = Math.Round(StandardDeviationX1, 3).ToString();
                x2stdv.Text = Math.Round(StandardDeviationX2, 3).ToString();
                x3stdv.Text = Math.Round(StandardDeviationX3, 3).ToString();

                //ANOVA Summary (error - SS)
                error2.Text = Math.Round((varianceX1T + varianceX2T + varianceX3T), 4).ToString();
                // error3 = treat3 / error3
                error3.Text = Math.Round(((varianceX1T + varianceX2T + varianceX3T) / ((x_val1.Length + x_val2.Length + x_val3.Length) - 3)), 4).ToString();
                // total2 = treat2 + error2
                total2.Text = (Math.Round(treat2val, 4) + Math.Round((varianceX1T + varianceX2T + varianceX3T), 4)).ToString();
                // treat4 = treat3 / error3
                treat4.Text = Math.Round(((treat2val / (3 - 1)) / ((varianceX1T + varianceX2T + varianceX3T) / ((x_val1.Length + x_val2.Length + x_val3.Length) - 3))), 4).ToString();

                rsquared.Text = Math.Round((1 - (Convert.ToDouble(treat2.Text) / Convert.ToDouble(total2.Text))), 4).ToString();
                rsquaredadj.Text = Math.Round((1 - (((Convert.ToDouble(total1.Text) / Convert.ToDouble(treat1.Text)) * (Convert.ToDouble(treat2.Text) / Convert.ToDouble(total2.Text))))), 4).ToString();

                int inclusiveStart = 0;
                int exclusiveEnd = x_val1.Length;
                double x1; //= 0;
                double x2; //= 0;
                double x3; //= 0;
                double y = 0;
                double sumx1_y = 0;
                double sumx2_y = 0;
                double sumx3_y = 0;
                double sumy_y = 0;
                double sumx1_x2 = 0;
                double sumx2_x3 = 0;
                double sumx1_x3 = 0;
                double sumx1_x1 = 0;
                double sumx2_x2 = 0;
                double sumx3_x3 = 0;

                for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
                {
                    x1 = x_val1[ctr];
                    x2 = x_val2[ctr];
                    x3 = x_val3[ctr];
                    y = y_vals[ctr];

                    sumx1_y += Math.Round((x1 * y), 3);
                    sumx2_y += Math.Round((x2 * y), 3);
                    sumx3_y += Math.Round((x3 * y), 3);
                    sumy_y += Math.Round((y * y), 3);
                    sumx1_x1 += Math.Round((x1 * x1), 3);
                    sumx2_x2 += Math.Round((x2 * x2), 3);
                    sumx3_x3 += Math.Round((x3 * x3), 3);
                    sumx1_x2 += Math.Round((x1 * x2), 3);
                    sumx2_x3 += Math.Round((x2 * x3), 3);
                    sumx1_x3 += Math.Round((x1 * x3), 3);

                    x1yvaluestxtbox.Text += Math.Round((x1 * y), 3) + "," + "\r\n";
                    x2yvaluestxtbox.Text += Math.Round((x2 * y), 3) + "," + "\r\n";
                    x3yvaluestxtbox.Text += Math.Round((x3 * y), 3) + "," + "\r\n";
                    x1x1valuestxtbox.Text += Math.Round((x1 * x1), 3) + "," + "\r\n";
                    x2x2valuestxtbox.Text += Math.Round((x2 * x2), 3) + "," + "\r\n";
                    x3x3valuestxtbox.Text += Math.Round((x3 * x3), 3) + "," + "\r\n";
                    x1x2valuestxtbox.Text += Math.Round((x1 * x2), 3) + "," + "\r\n";
                    x2x3valuestxtbox.Text += Math.Round((x2 * x3), 3) + "," + "\r\n";
                    x1x3valuestxtbox.Text += Math.Round((x1 * x3), 3) + "," + "\r\n";
                    yymvaluestxtbox.Text += Math.Round((y * y), 3) + "," + "\r\n";

                }

                sumx1y.Text += sumx1_y.ToString();
                sumx2y.Text += sumx2_y.ToString();
                sumx3y.Text += sumx3_y.ToString();
                sumyym.Text += sumy_y.ToString();
                sumx1x1.Text += sumx1_x1.ToString();
                sumx2x2.Text += sumx2_x2.ToString();
                sumx3x3.Text += sumx3_x3.ToString();
                sumx1x2.Text += sumx1_x2.ToString();
                sumx2x3.Text += sumx2_x3.ToString();
                sumx1x3.Text += sumx1_x3.ToString();

                //double r1 = ((0.997404903 * 0.997404903) + (-0.7324762 * -0.7324762) - (2 * (0.997404903 * -0.7324762 * -0.681560844649687)));
                //double r2 = 1 - (-0.681560844649687 * -0.681560844649687);
                //double r3 = r1 / r2;
                //double r4 = Math.Sqrt(r3);
                //MessageBox.Show(r4.ToString());
                //Y’ = a + b1*X1 + b2*X2 + b3*X3
                //Y’ = predicted value of Y
                //a = "Y Intercept"

                // need b1, b2 , b3 values as F1, F2, F3 values

                double b1 = ((cor_x1y - (cor_x2y * cor_x1x2)) / (1 - (cor_x1x2 * cor_x1x2))) * (StandardDeviationY / StandardDeviationX1);
                double b2 = ((cor_x2y - (cor_x1y * cor_x1x2)) / (1 - (cor_x1x2 * cor_x1x2))) * (StandardDeviationY / StandardDeviationX2);
                double b3 = ((cor_x3y - (cor_x1y * cor_x1x3)) / (1 - (cor_x1x3 * cor_x1x3))) * (StandardDeviationY / StandardDeviationX3);

                //rsquared = r4;

                F1 = b1;
                F2 = b2;
                F3 = b3;

                x1coeff.Text = Math.Round(b1, 3).ToString();
                x2coeff.Text = Math.Round(b2, 3).ToString();
                x3coeff.Text = Math.Round(b3, 3).ToString();
                interceptm.Text = (Math.Round(b1, 3) * sum_x1 + Math.Round(b2, 3) * sum_x2 + Math.Round(b3, 3) * sum_x3 - sum_y).ToString();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public double Correlation(double[] array1, double[] array2)
        {

            double[] array_xy = new double[array1.Length];
            double[] array_xp2 = new double[array1.Length];
            double[] array_yp2 = new double[array1.Length];

            for (int i = 0; i < array1.Length; i++)

                array_xy[i] = array1[i] * array2[i];

            for (int i = 0; i < array1.Length; i++)

                array_xp2[i] = Math.Pow(array1[i], 2.0);

            for (int i = 0; i < array1.Length; i++)

                array_yp2[i] = Math.Pow(array2[i], 2.0);

            double sum_x = 0;
            double sum_y = 0;

            foreach (double n in array1)
                sum_x += n;

            foreach (double n in array2)
                sum_y += n;

            double sum_xy = 0;

            foreach (double n in array_xy)
                sum_xy += n;

            double sum_xpow2 = 0;

            foreach (double n in array_xp2)
                sum_xpow2 += n;

            double sum_ypow2 = 0;

            foreach (double n in array_yp2)
                sum_ypow2 += n;

            double Ex2 = Math.Pow(sum_x, 2.00);
            double Ey2 = Math.Pow(sum_y, 2.00);

            double result = (array1.Length * sum_xy - sum_x * sum_y) / Math.Sqrt((array1.Length * sum_xpow2 - Ex2) * (array1.Length * sum_ypow2 - Ey2));
            
            return (result);

        }

        private void M2Chart1Code()
        {
            double[] yM2 = y_val;
            double[] x1M2 = F1_val;
            double[] x2M2 = F2_val;


            try
            {
                //Mchart1.Series[0].XAxisType = AxisType.Primary;
                //Mchart1.Series[1].XAxisType = AxisType.Secondary;

                Mchart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                Mchart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                Mchart1.ChartAreas[0].AxisY2.MajorGrid.LineWidth = 0;

                Mchart1.ChartAreas[0].AxisX.Title = ytextbox.Text;
                Mchart1.ChartAreas[0].AxisY.Title = x1textbox.Text;
                Mchart1.ChartAreas[0].AxisY2.Title = x2textbox.Text;

                Mchart1.BackColor = System.Drawing.Color.LightGray;

                Mchart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                Mchart1.ChartAreas[0].AxisY2.LabelStyle.Enabled = true;

                Mchart1.ChartAreas[0].AxisX.Interval = Math.Round(yM2.Average() / 2);  //(yM2.Length) / 2;
                Mchart1.ChartAreas[0].AxisX.Minimum = yM2.Min() - 1;

                Mchart1.ChartAreas[0].AxisY.Interval = Math.Round(x1M2.Average() / 2);  //(x1M2.Length) / 2;
                Mchart1.ChartAreas[0].AxisY.Minimum = x1M2.Min() - 1; ;

                Mchart1.ChartAreas[0].AxisY2.Interval = Math.Round(x2M2.Average() / 2);
                Mchart1.ChartAreas[0].AxisY2.Minimum = x2M2.Min() - 1;

                // X1 axis points                                               
                Series s1 = new Series("Slope");
                Mchart1.Series.Add(s1);
                Mchart1.Series[0].ChartType = SeriesChartType.Point;
                Mchart1.Palette = ChartColorPalette.None;
                Mchart1.PaletteCustomColors = new Color[] { Color.DarkGreen, Color.Red };  // Green for X1 , Blue for X2 points
                Mchart1.Series[0].MarkerStyle = MarkerStyle.Circle;
                for (int i = 0; i < yM2.Length; i++)
                {
                    Mchart1.Series[0].Points.AddXY(yM2[i], x1M2[i]);  // reverse the order to show two x1 and x2 axis lines                    
                }

                // X2 axis points
                var s2 = new Series("Slope2");
                Mchart1.Series.Add(s2);
                Mchart1.Series[1].ChartType = SeriesChartType.Point;
                Mchart1.Series[1].MarkerStyle = MarkerStyle.Cross;
                for (int i = 0; i < yM2.Length; i++)
                {
                    Mchart1.Series[1].Points.AddXY(yM2[i], x2M2[i]);
                }

                //Mchart1.Series[1].ToolTip = "X2: #x2M2"; // x2M2.ToString(); x2valuestxtbox
                //Mchart1.Series[0].ToolTip = "X1: #x1M2"; // x1M2.ToString(); x1valuestxtbox

                //// Create a new legend called "Legend2".
                Mchart1.Legends.Add(new Legend("Legend"));
                Mchart1.Series[0].Legend = "Legend";
                Mchart1.Series[0].IsVisibleInLegend = true;
                Mchart1.Series[0].LegendText = x1textbox.Text;
                Mchart1.Series[1].IsVisibleInLegend = true;
                Mchart1.Series[1].LegendText = x2textbox.Text;
                //Mchart1.Titles.Clear();

                //Mchart1.Series[0].LegendText = "";

                //// changes the width of the chart.
                Mchart1.ChartAreas[0].Position.X = 5;
                Mchart1.ChartAreas[0].Position.Width = 80;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("there is problem here!");
            }

        }


        /*
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
        */


        private void btnresetM_Click(object sender, EventArgs e)
        {
            ymvaluestxtbox.Text = "";
            x1valuestxtbox.Text = "";
            x2valuestxtbox.Text = "";
            x3valuestxtbox.Text = "";
            yymvaluestxtbox.Text = "";
            x1yvaluestxtbox.Text = "";
            x2yvaluestxtbox.Text = "";
            x3yvaluestxtbox.Text = "";
            x1x2valuestxtbox.Text = "";
            x2x3valuestxtbox.Text = "";
            x1x3valuestxtbox.Text = "";
            x1x1valuestxtbox.Text = "";
            x2x2valuestxtbox.Text = "";
            x3x3valuestxtbox.Text = "";
            sumym.Text = "";
            sumx1m.Text = "";
            sumx2m.Text = "";
            sumx3m.Text = "";
            sumx1x1.Text = "";
            sumx2x2.Text = "";
            sumx3x3.Text = "";
            sumx1x2.Text = "";
            sumx2x3.Text = "";
            sumx1x3.Text = "";
            sumyym.Text = "";
            sumx1y.Text = "";
            sumx2y.Text = "";
            sumx3y.Text = "";
            meanx1m.Text = "";
            meanx2m.Text = "";
            meanx3m.Text = "";
            meanym.Text = "";
            yvariance.Text = "";
            x1variance.Text = "";
            x2variance.Text = "";
            x3variance.Text = "";
            ystdv.Text = "";
            x1stdv.Text = "";
            x2stdv.Text = "";
            x3stdv.Text = "";
            interceptm.Text = "";
            x1coeff.Text = "";
            x2coeff.Text = "";
            x3coeff.Text = "";
            grandmean.Text = "";
            estefx1.Text = "";
            estefx2.Text = "";
            estefx3.Text = "";
            treat1.Text = "";
            treat2.Text = "";
            treat3.Text = "";
            treat4.Text = "";
            treat5.Text = "";
            error1.Text = "";
            error2.Text = "";
            error3.Text = "";
            total1.Text = "";
            total2.Text = "";
            txtnum.Text = "";
            rsquared.Text = "";
            rsquaredadj.Text = "";
            x1valuestxtbox.BackColor = Color.Gainsboro;
            x2valuestxtbox.BackColor = Color.Gainsboro;
            x3valuestxtbox.BackColor = Color.Gainsboro;
            x1valuestxtbox.ReadOnly = true;
            x2valuestxtbox.ReadOnly = true;
            x3valuestxtbox.ReadOnly = true;
            ytextbox.Text = "";
            x1textbox.Text = "";
            x2textbox.Text = "";
            x3textbox.Text = "";

            x1textbox.ReadOnly = true;
            x2textbox.ReadOnly = true;
            x3textbox.ReadOnly = true;

            Mchart1.Series.Clear();

            //Mchart1.Series[0].Points.Clear();
            //Mchart1.Series[1].Points.Clear();

            resultP0.Clear();
            resultP1.Clear();
        }

        private void btnactivate_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt16(txtnum.Text);
            numlable.Text = num.ToString();

            if (num == 2)
            {
                x1valuestxtbox.ReadOnly = false;
                x2valuestxtbox.ReadOnly = false;
                x1textbox.ReadOnly = false;
                x2textbox.ReadOnly = false;               

                ymvaluestxtbox.BackColor = Color.GreenYellow;
                x1valuestxtbox.BackColor = Color.GreenYellow;
                x2valuestxtbox.BackColor = Color.GreenYellow;
                x3valuestxtbox.BackColor = Color.Gainsboro;
                x3valuestxtbox.ReadOnly = true;
            }
            if (num == 3)
            {
                x1valuestxtbox.ReadOnly = false;
                x2valuestxtbox.ReadOnly = false;
                x3valuestxtbox.ReadOnly = false;
                x1textbox.ReadOnly = false;
                x2textbox.ReadOnly = false;
                x3textbox.ReadOnly = false;

                ymvaluestxtbox.BackColor = Color.GreenYellow;
                x1valuestxtbox.BackColor = Color.GreenYellow;
                x2valuestxtbox.BackColor = Color.GreenYellow;
                x3valuestxtbox.BackColor = Color.GreenYellow;
            }
            if (num != 2 && num != 3)
            {
                MessageBox.Show("Please enter 2 or 3");
            }

            //MessageBox.Show(num.ToString());
        }

        private void btnpredict_Click(object sender, EventArgs e)
        {
            try
            {
                double av = Convert.ToDouble(intercept.Text);
                double bv = Convert.ToDouble(slope1.Text);
                double xv = Convert.ToDouble(xvalue.Text);

                yvalue.Text = Math.Round((av + (bv * xv)), 4).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
