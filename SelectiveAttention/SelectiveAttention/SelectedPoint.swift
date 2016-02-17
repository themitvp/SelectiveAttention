//
//  SelectedPoint.swift
//  SelectiveAttention
//
//  Created by Jesper Østergaard on 14/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import Foundation

class SelectedPoint: NSObject, NSCoding {
    var tagId: Int!
    var selectedAfterTime: Int!
    var xCoordinate : Float!
    var yCoordinate : Float!
    
    
    init(tagId: Int, selectedAfterTime: Int, xCoordinate: Float,yCoordinate: Float) {
        self.tagId = tagId
        self.selectedAfterTime = selectedAfterTime
        self.xCoordinate = xCoordinate
        self.yCoordinate = yCoordinate
        
    }
    
    required convenience init(coder aDecoder: NSCoder) {
        let tagId = aDecoder.decodeObjectForKey("tagId") as! Int
        let selectedAfterTime = aDecoder.decodeIntegerForKey("selectedAfterTime")
        let xCoordinate = aDecoder.decodeObjectForKey("xCoordinate") as! Float
        let yCoordinate = aDecoder.decodeObjectForKey("yCoordinate") as! Float
        
        self.init(tagId: tagId, selectedAfterTime: selectedAfterTime, xCoordinate: xCoordinate,yCoordinate: yCoordinate)
    }
    
    func encodeWithCoder(aCoder: NSCoder) {
        aCoder.encodeObject(tagId, forKey: "tagId")
        aCoder.encodeInteger(selectedAfterTime, forKey: "selectedAfterTime")
        aCoder.encodeObject(xCoordinate, forKey: "xCoordinate")
        aCoder.encodeObject(yCoordinate, forKey: "yCoordinate")
        
    }
}