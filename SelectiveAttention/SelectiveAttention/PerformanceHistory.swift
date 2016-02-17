//
//  PerformanceHistory.swift
//  SelectiveAttention
//
//  Created by Jesper Østergaard on 14/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit

class PerformanceHistory: NSObject, NSCoding {
    var date: NSDate!
    var totalTime: Int!
    var switches: Int!
    var correct: Int!
    var selectedPoints : [SelectedPoint]!
    
    init(date: NSDate, totalTime: Int, switches: Int,correct: Int, selectedPoints : [SelectedPoint]) {
        self.date = date
        self.totalTime = totalTime
        self.switches = switches
        self.correct = correct
        self.selectedPoints = selectedPoints
        
    }
    
    required convenience init(coder aDecoder: NSCoder) {
        let date = aDecoder.decodeObjectForKey("date") as! NSDate
        let totalTime = aDecoder.decodeIntegerForKey("totalTime")
        let switches = aDecoder.decodeObjectForKey("switches") as! Int
        let correct = aDecoder.decodeObjectForKey("correct") as! Int
        let selectedPoints = aDecoder.decodeObjectForKey("selectedPoints") as! [SelectedPoint]
        
        self.init(date: date, totalTime: totalTime, switches: switches,correct: correct, selectedPoints : selectedPoints)
    }
    
    func encodeWithCoder(aCoder: NSCoder) {
        aCoder.encodeObject(date, forKey: "date")
        aCoder.encodeInteger(totalTime, forKey: "totalTime")
        aCoder.encodeObject(switches, forKey: "switches")
        aCoder.encodeObject(correct, forKey: "correct")
        aCoder.encodeObject(selectedPoints, forKey: "selectedPoints")
    }
}