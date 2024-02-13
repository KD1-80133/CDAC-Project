using EnitityModelLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLib;
using WebAPI.Model.PROJMEMBDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("/ProjectMembers")]
    [ApiController]
    [Authorize]

    public class ProjectMembersController : ControllerBase
    {
        ProjectMembersRepository service;
        public ProjectMembersController()
        {
            service = new ProjectMembersRepository();
        }
        // GET: api/<ProjectMembersController>
        [HttpGet]
        public IEnumerable<ProjMembDTO> Get()
        {
            List<ProjMembDTO> projmembDTOList = new List<ProjMembDTO>();
            foreach (ProjectMembers projmemb in service.GetAllProjectMembers())
            {
                ProjMembDTO pmdl = new ProjMembDTO();
                pmdl.ProjectId = projmemb.ProjectId;
                pmdl.ProjMemberId = projmemb.ProjMemberId;
                pmdl.UserId = projmemb.UserId;
                projmembDTOList.Add(pmdl);
            }
            return projmembDTOList;
        }

        // GET api/<ProjectMembersController>/5
        [HttpGet("{id}")]
        public ProjMembDTO Get(int id)
        {
            ProjectMembers projmemb = service.FindById(id);
            ProjMembDTO projmembDTO = new ProjMembDTO();
            projmembDTO.ProjMemberId = projmemb.ProjMemberId;
            projmembDTO.ProjectId = projmemb.ProjectId;
            projmembDTO.UserId = projmemb.UserId;
            return projmembDTO;
        }

        // POST api/<ProjectMembersController>
        [HttpPost]
        public void Post([FromBody] AddProjMembDTO apmd)
        {
            ProjectMembers projmemb = new ProjectMembers();
            projmemb.ProjectId = apmd.ProjectId;
            projmemb.UserId = apmd.UserId;

            service.Add(projmemb);

        }

        // PUT api/<ProjectMembersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ModifyProjMembDTO mpmd)
        {
            ProjectMembers tomodify = service.FindById(id);
            tomodify.ProjMemberId = id;
            tomodify.ProjectId = mpmd.ProjectId;
            tomodify.UserId = mpmd.UserId;
            service.Modify(tomodify);
        }

        // DELETE api/<ProjectMembersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Remove(id);
        }
    }
}