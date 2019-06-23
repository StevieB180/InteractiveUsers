using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using InteractiveUsers.Models;
using Microsoft.AspNet.SignalR;

namespace InteractiveUsers.Hubs
{
    public class MoveShapeHub : Hub
    {
        static ConcurrentDictionary<string, ShapeModel> movingShapesDictionary =
            new ConcurrentDictionary<string, ShapeModel>();

        public void FirstHandShake()
        {
            try
            {
                Parallel.ForEach(movingShapesDictionary, (movingShape) =>
                {
                    Clients.Caller.updateShape(movingShape.Value);
                });
            }
            catch
            {
            }


        }

        public void UpdateModel(ShapeModel shapeModel)
        {
            movingShapesDictionary[shapeModel.Id] = shapeModel;
            Clients.Others.updateShape(shapeModel);
        }
        public void AddNewShape(ShapeModel shapeModel)
        {
            movingShapesDictionary[shapeModel.Id] = shapeModel;
            Clients.Others.newShapeAdded(shapeModel);
        }
    }
}