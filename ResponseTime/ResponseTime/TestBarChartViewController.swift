//
//  TestBarChartViewController.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 17/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit
import Charts

//http://www.appcoda.com/ios-charts-api-tutorial/

class TestBarChartViewController: UIViewController, ChartViewDelegate {

    @IBOutlet weak var barChartView: BarChartView!
    var months: [String]!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        barChartView.delegate = self

        months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
        let unitsSold = [20.0, 4.0, 6.0, 3.0, 12.0, 16.0, 4.0, 18.0, 2.0, 4.0, 5.0, 4.0]
        let unitsBought = [20.0, 4.0, 6.0, 3.0, 12.0, 16.0, 4.0, 18.0, 2.0, 4.0, 5.0, 12.8]
        
        setChart(months, unitsSold: unitsSold, unitsBought : unitsBought)
        
        //barChartView.noDataText = "You need to provide data for the chart."
        //barChartView.noDataTextDescription = "GIVE REASON"
        // Do any additional setup after loading the view.
    }

    @IBAction func saveChart(sender: UIBarButtonItem) {
        barChartView.saveToCameraRoll()
        //barChartView.saveToPath(path: String, format: ChartViewBase.ImageFormat, compressionQuality: Double)
    }
    func chartValueSelected(chartView: ChartViewBase, entry: ChartDataEntry, dataSetIndex: Int, highlight: ChartHighlight) {
        print("\(entry.value) in \(months[entry.xIndex])")
    }
    func setChart(dataPoints: [String], unitsSold: [Double], unitsBought : [Double]) {
        barChartView.noDataText = "You need to provide data for the chart."
        
        
        var dataEntriesSold: [BarChartDataEntry] = []
        var dataEntriesBought: [BarChartDataEntry] = []
        
        for i in 0..<dataPoints.count {
            let dataEntrySold = BarChartDataEntry(value: unitsSold[i], xIndex: i)
            dataEntriesSold.append(dataEntrySold)
            
            let dataEntryBought = BarChartDataEntry(value: unitsBought[i], xIndex: i)
            dataEntriesBought.append(dataEntryBought)
        }

        let chartDataSetSold = BarChartDataSet(yVals: dataEntriesSold, label: "Units Sold")
        let chartDataSetBought = BarChartDataSet(yVals: dataEntriesBought, label: "Units Bought")
        
        let chartData = BarChartData(xVals: months, dataSets: [chartDataSetSold,chartDataSetBought])
        
        barChartView.data = chartData
        
        barChartView.descriptionText = ""
        //chartDataSet.colors = [UIColor(red: 230/255, green: 126/255, blue: 34/255, alpha: 1)]
        //chartDataSetSold.colors = ChartColorTemplates.colorful()
        barChartView.xAxis.labelPosition = .Bottom
        
        barChartView.backgroundColor = UIColor(red: 189/255, green: 195/255, blue: 199/255, alpha: 1)
        
        //barChartView.animate(xAxisDuration: 2.0, yAxisDuration: 2.0)

        barChartView.animate(xAxisDuration: 2.0, yAxisDuration: 2.0, easingOption: .EaseInBounce)
        

        let ll = ChartLimitLine(limit: 10.0, label: "Target")
        barChartView.rightAxis.addLimitLine(ll)
        
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
