//
//  Team.swift
//  SelectiveAttention
//
//  Created by Jesper Østergaard on 14/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import Foundation

class Team: NSObject, NSCoding {
    var id: Int!
    var name: NSString!
    var shortname: NSString!
    var date: NSDate!
    var time: Int!
    var testValue: Int!
    //var correct: Int!
    
    init(id: Int, name:NSString, shortname: NSString, date : NSDate, time: Int,testValue: Int) {
        self.id = id
        self.name = name
        self.shortname = shortname
        self.date = date
        self.time = time
        //correct: Int
        self.testValue = testValue
        //self.correct = correct
        
    }
    
    required convenience init(coder aDecoder: NSCoder) {
        let id = aDecoder.decodeIntegerForKey("id")
        let name = aDecoder.decodeObjectForKey("name") as! String
        let shortname = aDecoder.decodeObjectForKey("shortname") as! String
        let date = aDecoder.decodeObjectForKey("date") as! NSDate
        let time = aDecoder.decodeIntegerForKey("time")
        let testValue = aDecoder.decodeObjectForKey("testValue") as! Int
        //let correct = aDecoder.decodeIntegerForKey("correct")

        //, switches: switches,correct: correct
        self.init(id: id, name: name, shortname: shortname, date : date, time: time,testValue : testValue)
    }
    
    func encodeWithCoder(aCoder: NSCoder) {
        aCoder.encodeInteger(id, forKey: "id")
        aCoder.encodeObject(name, forKey: "name")
        aCoder.encodeObject(shortname, forKey: "shortname")
        aCoder.encodeObject(date, forKey: "date")
        aCoder.encodeInteger(time, forKey: "time")
        aCoder.encodeObject(testValue, forKey: "testValue")
        //aCoder.encodeObject(correct, forKey: "correct")
    }
}