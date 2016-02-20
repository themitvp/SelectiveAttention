//
//  TestTwoGraphViewController.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 20/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit
import Charts

class TestTwoGraphViewController: UIViewController, ChartViewDelegate {
    
    
    @IBOutlet weak var barChartView: BarChartView!

    override func viewDidLoad() {
        super.viewDidLoad()
        
        barChartView.delegate = self
        let delays = [0.05, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0, 1.1, 1.2]
        var values = [0,0,0,0,0,0,0,0,0,0,0,0,0]
        var valuesTwo = [0,0,0,0,0,0,0,0,0,0,0,0,0]
        
        
        if NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksTwo") != nil {
            let doubleClick = NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksTwo") as! [Double]
            
            for value in doubleClick {
                let index = delays.indexOf(value)
                values[index!] = values[index!]+1
            }
        }
        if NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") != nil {
            let decoded  = NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") as! NSData
            let itemsOne = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [ClickItem]
            print(itemsOne)
            for value in itemsOne{
                if let index = delays.indexOf(value.delay){
                    valuesTwo[index] = valuesTwo[index]+1
                }
            }
            
        }
        
        self.setChart(delays,values: values, valuesTwo : valuesTwo)
        
    }
    
    @IBAction func saveChart(sender: UIBarButtonItem) {
        barChartView.saveToCameraRoll()
        //barChartView.saveToPath(path: String, format: ChartViewBase.ImageFormat, compressionQuality: Double)
    }
    func setChart(delays: [Double], values: [Int], valuesTwo : [Int]) {
        barChartView.noDataText = "You need to provide data for the chart."
        
        
        var dataEntries: [BarChartDataEntry] = []
        var dataEntriesTwo: [BarChartDataEntry] = []
        
        for i in 0..<delays.count {
            let dataEntry = BarChartDataEntry(value: Double(values[i]), xIndex: i)
            dataEntries.append(dataEntry)
            
            let dataEntryTwo = BarChartDataEntry(value: Double(valuesTwo[i]), xIndex: i)
            dataEntriesTwo.append(dataEntryTwo)
        }
        
        let chartDataSet = BarChartDataSet(yVals: dataEntries, label: "Number of double clicks")
        let chartDataSetTwo = BarChartDataSet(yVals: dataEntriesTwo, label: "Clicks after image removed")
        
        let chartData = BarChartData(xVals: ["0.05", "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1.0", "1.1", "1.2"], dataSets:[chartDataSet, chartDataSetTwo])
        
        barChartView.data = chartData
        
        barChartView.descriptionText = ""
        chartDataSet.colors = [UIColor(red: 0/255, green: 0/255, blue: 102/255, alpha: 1)]
        chartDataSetTwo.colors = [UIColor(red: 255/255, green: 126/255, blue: 34/255, alpha: 1)]
        barChartView.xAxis.labelPosition = .Bottom
        
        barChartView.backgroundColor = UIColor(red: 189/255, green: 195/255, blue: 199/255, alpha: 1)
        
        barChartView.animate(xAxisDuration: 2.0, yAxisDuration: 2.0)
        
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
